using Microsoft.AspNetCore.Mvc;
using SiteASP.Data;
using SiteASP.Models;
using System.Text.RegularExpressions;

namespace SiteASP.Controllers
{
    public class RegController : Controller
    {
        private readonly AppDBContent _dbContext;
        public RegController(AppDBContent dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /Reg/Index
        public IActionResult Index()
        {
            return View();
        }
        // POST: /Reg/Check
        [HttpPost]
        public IActionResult Check(Reg reg)
        {
            if (ModelState.IsValid)
            {
                // Дополнительные проверки логина и пароля
                if (!Regex.IsMatch(reg.Login ?? string.Empty, @"^[a-zA-Z0-9]+$"))
                {
                    ModelState.AddModelError("Login", "Логин должен содержать только латинские буквы и цифры");
                }
                if (!Regex.IsMatch(reg.Password ?? string.Empty, @"^[a-zA-Z0-9]+$"))
                {
                    ModelState.AddModelError("Password", "Пароль должен содержать только латинские буквы и цифры");
                }
                // Проверка уникальности логина
                if (IsLoginUnique(reg.Login ?? string.Empty))
                {
                    // Сохранение нового пользователя
                    _dbContext.User.Add(new User
                    {
                        Login = reg.Login,
                        Password = reg.Password,
                        FIO = reg.FIO,
                        Email = reg.Email,
                        PhoneNumber = reg.Phone,
                        Photo = reg.Photo
                    });
                    _dbContext.SaveChanges();
                    TempData["SuccessMessage"] = "Вы успешно зарегистрированы!";

                    return View("Index", reg);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким логином уже существует");
                    TempData["ErrorMessage"] = "Пользователь с таким логином уже существует!";
                }
            }
            return View("Index", reg);
        }
        // Метод для проверки уникальности логина
        private bool IsLoginUnique(string login)
        {
            return _dbContext.User.FirstOrDefault(u => u.Login == login) == null;
        }


    }
}
