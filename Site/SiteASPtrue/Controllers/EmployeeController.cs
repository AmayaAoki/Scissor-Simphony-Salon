using Microsoft.AspNetCore.Mvc;
using SiteASP.Interfaces;
using SiteASP.Models;
using SiteASP.ViewModels;

namespace SiteASP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAllEmployee _allemp;
        // Используем конструктор для внедрения зависимости IAllEmployee
        public EmployeeController(IAllEmployee allEmployee)
        {
            _allemp = allEmployee;
        }
        public IActionResult Index()
        {
            // Создаем объект модели EmployeeViewModel
            var viewModel = new EmployeeViewModel
            {
                // Получаем список всех сотрудников через интерфейс IAllEmployee
                AllEmployee = _allemp.Employee
            };
            
            return View(viewModel);
        }

        // Обработчик POST-запроса для сохранения данных
        [HttpPost]
        public IActionResult Save(string serviceName)
        {
            // Устанавливаем значение имени сотрудника в глобальной переменной
            GlobalClass.EmployeeName = serviceName;
            
            return RedirectToAction("Index", "Appointments");
        }

    }
}
