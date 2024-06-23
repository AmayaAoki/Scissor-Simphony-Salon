using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QRCoder;
using SiteASP.Data;
using SiteASP.Data.Repository;
using SiteASP.Interfaces;
using SiteASP.Models;
using SiteASP.ViewModels;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

using System.IO;

namespace SiteASP.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAllAppointments _allAppointments;
        private readonly IAllServices _allServices;
        private readonly AppDBContent _db;
        public AppointmentsController(AppDBContent db, IAllAppointments allAppointments, IAllServices allServices)
        {
            _db = db;
            _allAppointments = allAppointments;
            _allServices = allServices;
        }

        public IActionResult Index()
        {
            var employees = _db.Employee.ToList(); // Получаем всех работников из таблицы Employee
            var services = _db.Service.ToList(); // Получаем все услуги из таблицы Service
            // Проверяем, есть ли данные о работниках
            if (employees.Any())
            {
                // Находим объект работника, соответствующий имени из переменной EmployeeName
                var selectedEmployee = employees.FirstOrDefault(e => e.FIO == GlobalClass.EmployeeName);
                // Если работник найден, перемещаем его в начало списка
                if (selectedEmployee != null)
                {
                    employees.Remove(selectedEmployee); // Удаляем работника из списка
                    employees.Insert(0, selectedEmployee); // Вставляем его в начало списка
                }
            }
            else
            {
                employees = new List<Employee>(); // Создаем пустой список, если данных нет
            }
            // Проверяем, есть ли данные о услугах
            if (services.Any())
            {
                // Находим объект услуги, соответствующий имени из переменной ServiceName
                var selectedService = services.FirstOrDefault(s => s.ProcedureName == GlobalClass.ServiceName);
                // Если услуга найдена, перемещаем её в начало списка
                if (selectedService != null)
                {
                    services.Remove(selectedService); // Удаляем услугу из списка
                    services.Insert(0, selectedService); // Вставляем её в начало списка
                }
            }
            else
            {
                services = new List<Services>(); // Создаем пустой список, если данных нет
            }
            // Передаем списки в представление
            ViewBag.Employee = new SelectList(employees, "FIO", "FIO");
            ViewBag.Service = new SelectList(services, "ProcedureName", "ProcedureName");
            // Генерируем список допустимых временных интервалов
            var allowedTimes = GenerateAllowedTimes();
            ViewBag.EventTime = new SelectList(allowedTimes); // Используем SelectList для временных интервалов
            // Устанавливаем значение статуса
            ViewBag.Status = "Создан";

            return View();
        }
        private List<string> GenerateAllowedTimes()
        {
            var times = new List<string>();
            TimeSpan startTime = new TimeSpan(9, 0, 0); // 9:00 AM
            TimeSpan endTime = new TimeSpan(18, 0, 0); // 6:00 PM
            TimeSpan interval = new TimeSpan(0, 30, 0); // 30 minutes interval

            for (TimeSpan time = startTime; time <= endTime; time += interval)
            {
                // Формируем строку времени в нужном формате "чч:мм"
                string formattedTime = time.ToString(@"hh\:mm");
                times.Add(formattedTime);
            }
            return times;
        }

        [HttpPost]
        public async Task<IActionResult> Save(Appointments appointment)
        {
            appointment.Status = "Создан";
            try
            {
                if (string.IsNullOrEmpty(GlobalClass.FIO) || GlobalClass.FIO == "None")
                {
                    // Если пользователь не авторизован, перенаправляем на страницу авторизации
                    return RedirectToAction("Index", "Enter");
                }
                // Добавляем проверку, если выбранная дата предшествует завтрашнему числу, выводим ошибку
                if (!appointment.Date.HasValue)
                {
                    TempData["ErrorMessage"] = "Выберите дату.";
                }
                else if (appointment.Date.Value.Date < DateTime.Now.Date.AddDays(1))
                {
                    TempData["ErrorMessage"] = "Выберите дату, которая не предшествует завтрашнему числу.";
                }
                else
                {
                    // Проверка наличия записей на указанную дату и время для выбранного сотрудника
                    var conflictingAppointments = _db.Appointments
                        .Where(a => a.Date == appointment.Date && a.EmployeeID == appointment.EmployeeID)
                        .ToList();

                    if (conflictingAppointments.Any(a => a.EventTime == appointment.EventTime))
                    {
                        var occupiedTimes = conflictingAppointments
                        .OrderBy(a => a.EventTime) // Сортировка по возрастанию времени
                        .Select(a => a.EventTime.ToString(@"hh\:mm")); // Преобразование времени в строковый формат

                        TempData["ErrorMessage"] = "На указанную дату и время уже существует запись. Занятые времена: " + string.Join(", ", occupiedTimes);
                    }
                    else
                    {
                        _db.Appointments.Add(appointment);
                        await _db.SaveChangesAsync();

                        TempData["SuccessMessage"] = "Успешная запись!";
                        return RedirectToAction("Index", "Appointments");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Сообщение о внутренней ошибки: " + ex.InnerException.Message);
                    Console.WriteLine("Кодировка внутренней ошибки:: " + ex.InnerException.StackTrace);
                }
            }
            // Если модель недопустима или возникла ошибка, возвращаемся на ту же страницу с моделью, чтобы показать ошибки валидации
            return RedirectToAction("Index", appointment);
        }

        [HttpPost]
        public IActionResult RedirectToAppointmentPage()
        {
            // Перенаправляем пользователя на нужную страницу
            return RedirectToAction("Records", "Appointments"); 
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Метод для отображения списка записей
        public IActionResult Records(string filtervalue = "Без фильтра")
        {
            var allAppointments = _allAppointments.Appointments;
            Console.WriteLine($"Filter value: {filtervalue}");

            if (filtervalue != "Без фильтра" && !string.IsNullOrEmpty(filtervalue))
            {
                if (!string.IsNullOrEmpty(GlobalClass.FIO))
                {
                    allAppointments = allAppointments.Where(a => a.UserID == GlobalClass.FIO && a.Status == filtervalue);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(GlobalClass.FIO))
                {
                    allAppointments = allAppointments.Where(a => a.UserID == GlobalClass.FIO);
                }
            }
            var viewModel = new AppointmentsViewModel
            {
                AllAppointments = allAppointments.ToList(),
                CurrentFilter = filtervalue,
                AllServices = _db.Service.ToList() // метод получения всех услуг
            };

            return View(viewModel);
        }

        public IActionResult GetModalPartialView(int id, string employeeId, string serviceId, string date, string EventTime, string status)
        {
            // Выводим значения переменных в консоль
            Console.WriteLine($"AppointmentId: {id}");
            Console.WriteLine($"EmployeeId: {employeeId}");
            Console.WriteLine($"ServiceId: {serviceId}");
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"EventTime: {EventTime}");
            Console.WriteLine($"Status: {status}");

            ViewBag.AppointmentId = id;
            ViewBag.EmployeeId = employeeId;
            ViewBag.ServiceId = serviceId;
            ViewBag.Date = date;
            ViewBag.EventTime = EventTime;
            ViewBag.Status = status;

            return PartialView("_ModalPartial");
        }

        public IActionResult GenerateQRCode(string qrData)
        {
            try
            {
                if (string.IsNullOrEmpty(qrData))
                {
                    return Content("Нет данных для генерации QR-кода.");
                }
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                byte[] qrCodeBytes = qrCode.GetGraphic(20);

                return File(qrCodeBytes, "image/png");
            }
            catch (Exception ex)
            {
                return Content("Ошибка при генерации QR-кода: " + ex.Message);
            }
        }

        // сохранение данных для модульного окна
        [HttpPost]
        public IActionResult SaveSelectedRow([FromBody] SelectedRowData data)
        {
            if (data == null)
            {
                Console.WriteLine("Полученные данные: null");
                return Json(new { message = "Полученные данные: null" });
            }
            Console.WriteLine($"Полученные данные: EmployeeId={data.EmployeeId}, ServiceId={data.ServiceId}, Date={data.Date}, EventTime = {data.EventTime}, Status={data.Status}");
            // Парсим дату из строки
            if (DateTime.TryParse(data.Date, out DateTime parsedDate))
            {
                GlobalClass.EmployeeId = data.EmployeeId;
                GlobalClass.ServiceId = data.ServiceId;
                GlobalClass.Date = parsedDate;

                if (TimeSpan.TryParse(data.EventTime, out TimeSpan parsedTime))
                {
                    GlobalClass.EventTime = parsedTime;
                }
                else
                {
                    return Json(new { message = $"Некорректный формат времени: {data.EventTime}" });
                }

                GlobalClass.Status = data.Status;
            }
            else
            {
                return Json(new { message = "Некорректный формат даты" });
            }
            var appointment = _db.Appointments.FirstOrDefault(a => a.EmployeeID == GlobalClass.EmployeeId &&
                                                                    a.ServiceID == GlobalClass.ServiceId &&
                                                                    a.Date == parsedDate &&
                                                                    a.EventTime == GlobalClass.EventTime &&
                                                                    a.Status == GlobalClass.Status);
            if (appointment == null)
            {
                return Json(new { message = "Запись не найдена" });
            }
            // Получаем ID записи
            var appointmentId = appointment.Id;
            GlobalClass.AppointmentId = appointmentId;

            return Json(new { message = "Данные успешно сохранены", appointmentId = appointmentId });
        }

        public class SelectedRowData
        {
            public string EmployeeId { get; set; }
            public string ServiceId { get; set; }
            public string Date { get; set; } 
            public string EventTime { get; set; }
            public string Status { get; set; }
        }

        // удаление записи
        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            var appointment = await _db.Appointments.FindAsync(GlobalClass.AppointmentId);
            
            if (appointment != null)
            {
                _db.Appointments.Remove(appointment);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Запись успешно отменена." });
            }
            
            return Json(new { success = false, message = "Запись не найдена." });
        }

        // перенос записи
        [HttpPost]
        public async Task<IActionResult> MoveAppointment(int appointmentId, DateTime newDate, string newTime)
        {
            var appointment = await _db.Appointments.FindAsync(GlobalClass.AppointmentId);
            if (appointment != null)
            {
                if (TimeSpan.TryParse(newTime, out TimeSpan parsedTime))
                {
                    // Проверка наличия записей на новую дату и время
                    var conflictingAppointments = _db.Appointments
                        .Where(a => a.Date == newDate && a.EmployeeID == appointment.EmployeeID && a.Id != appointmentId)
                        .ToList();

                    if (conflictingAppointments.Any(a => a.EventTime == parsedTime))
                    {
                        var occupiedTimes = conflictingAppointments
                        .OrderBy(a => a.EventTime) // Сортировка по возрастанию времени
                        .Select(a => a.EventTime.ToString(@"hh\:mm")); // Преобразование времени в строковый формат
                        return Json(new { success = false, message = "На указанную дату и время уже существует запись.", occupiedTimes = string.Join(", ", occupiedTimes) });
                    }
                    appointment.Date = newDate;
                    appointment.EventTime = parsedTime;
                    await _db.SaveChangesAsync();
                    return Json(new { success = true, message = "Запись успешно перенесена." });
                }
                else
                {
                    return Json(new { success = false, message = $"Некорректный формат времени: {newTime}" });
                }
            }
            return Json(new { success = false, message = "Запись не найдена." });
        }


    }
}
