using Microsoft.AspNetCore.Mvc;
using SiteASP.Data;
using SiteASP.Models;

namespace SiteASP.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDBContent _context;
        public ProfileController(AppDBContent context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Получаем информацию о пользователе из глобального класса
            User user = new User
            {
                Id = GlobalClass.UserId,
                Login = GlobalClass.Login ?? string.Empty,
                Password = GlobalClass.Password ?? string.Empty,
                FIO = GlobalClass.FIO ?? string.Empty,
                Email = GlobalClass.Email ?? string.Empty,
                PhoneNumber = GlobalClass.PhoneNumber ?? string.Empty,
                Photo = GlobalClass.Photo ?? string.Empty
            };
            // Проверяем, был ли найден пользователь
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Save(User user)
        {
            // Проверяем на пустые значения
            if (string.IsNullOrWhiteSpace(user.Login) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.FIO) ||
                string.IsNullOrWhiteSpace(user.PhoneNumber) ||
                string.IsNullOrWhiteSpace(user.Email))
            {
                TempData["CancelMessage"] = "Все поля должны быть заполнены.";
                return RedirectToAction("Index", user);
            }
            // Получаем пользователя из базы данных
            var existingUser = _context.User.Find(GlobalClass.UserId);
            // Проверяем, существует ли пользователь
            if (existingUser == null)
            {
                return NotFound();
            }
            
            // Сохраняем старое FIO для обновления записей в таблице Appointments
            var oldFIO = existingUser.FIO;
            // Обновляем данные пользователя
            existingUser.Login = user.Login;
            existingUser.Password = user.Password;
            existingUser.FIO = user.FIO;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Email = user.Email;
            existingUser.Photo = user.Photo;

            GlobalClass.Login = user.Login; 
            GlobalClass.Password = user.Password;
            GlobalClass.FIO = user.FIO;
            GlobalClass.PhoneNumber = user.PhoneNumber;
            GlobalClass.Email = user.Email;            
            GlobalClass.Photo = user.Photo;

            // Обновляем записи в таблице Appointments
            var userAppointments = _context.Appointments.Where(a => a.UserID == oldFIO).ToList();
            foreach (var appointment in userAppointments)
            {
                appointment.UserID = user.FIO;
            }
            // Сохраняем изменения в базе данных
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Профиль изменен.";
            // После сохранения перенаправляем пользователя на главную страницу или другую страницу
            return RedirectToAction("Index", user);
        }

        [HttpPost]
        public IActionResult CancelChanges(User user)
        {
            TempData["CancelMessage"] = "Изменения были сброшены.";
            return RedirectToAction("Index", user);
        }

        [HttpPost]
        public IActionResult Delete()
        {
            try
            {
                // Получаем информацию о пользователе из глобального класса или из базы данных
                User user = new User
                {
                    Id = GlobalClass.UserId
                };
                // Удаляем профиль из базы данных
                _context.User.Remove(user);
                _context.SaveChanges();

                // Сбрасываем информацию о пользователе в глобальном классе
                GlobalClass.IsAutorized = false;
                GlobalClass.SessionValue = string.Empty;
                GlobalClass.UserId = 0;
                GlobalClass.Login = string.Empty;
                GlobalClass.Password = string.Empty;
                GlobalClass.FIO = string.Empty;
                GlobalClass.Email = string.Empty;
                GlobalClass.PhoneNumber = string.Empty;
                GlobalClass.Photo = string.Empty;

                return Ok("Аккаунт успешно удален!");
            }
            catch (Exception)
            {
                return BadRequest("Произошла ошибка при удалении аккаунта.");
            }
        }


    }
}
