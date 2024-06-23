using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiteASP.Data.Repository;
using SiteASP.Models;
using SiteASP.ViewModels;
using System.Diagnostics;


namespace SiteASP.Controllers
{
    public class EnterController : Controller
    {
        public IActionResult Index()
        {
            // Проверяем, авторизован ли пользователь
            if (GlobalClass.IsAutorized)
            {
                // Если пользователь авторизован, заполняем поле UserEmail его email
                var contact = new Contact {UserEmail = GlobalClass.Email ?? string.Empty };
                return View(contact);
            }
            
            return View();
        }

        private readonly IUserRepository _userRepository;

        public EnterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Check(EnterViewModel user) 
        {
            if (ModelState.IsValid)
            {
                // Подключение к базе данных и поиск пользователя
                var authenticatedUser = _userRepository.Authenticate(user.Login ?? string.Empty, user.Password ?? string.Empty);

                if (authenticatedUser != null)
                {
                    if (authenticatedUser.Login == null || authenticatedUser.Password == null)
                    {
                        // Обработка случая, когда значения Login или Password равны null
                        ModelState.AddModelError(string.Empty, "Данные пользователя некорректны");
                       
                        return View("Index", user);
                    }
                    
                    // Пользователь найден, сохраняем его логин в сессию
                    HttpContext.Session.SetString("CurrentUser", authenticatedUser.Login);
                                  
                    // Получаем значение из сессии
                    var value = HttpContext.Session.GetString("CurrentUser");
                    Debug.WriteLine("Значение переменной value: " + value);
                    // Устанавливаем значение в ViewData
                    ViewData["SessionValue"] = value;

                    //----------------------------------------------------------
                    GlobalClass.SessionValue = value;
                    GlobalClass.IsAutorized = true;

                    GlobalClass.UserId = authenticatedUser.Id;                   
                    GlobalClass.Login = authenticatedUser.Login;
                    GlobalClass.Password = authenticatedUser.Password;
                    GlobalClass.FIO = authenticatedUser.FIO;
                    GlobalClass.Email = authenticatedUser.Email;
                    GlobalClass.PhoneNumber = authenticatedUser.PhoneNumber;
                    GlobalClass.Photo = authenticatedUser.Photo;

                    return RedirectToAction("Records", "Appointments");
                }
                else
                {
                    // Пользователь не найден или введен неправильный пароль, отобразите сообщение об ошибке
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                    TempData["ErrorMessage"] = "Неверный логин или пароль. Попробуйте еще раз.";
                }
            }
            return View("Index", user);
        }

        [HttpPost]
        // Действие для выхода из аккаунта
        public IActionResult Logout()
        {
            // Удаляем данные о текущем пользователе из сессии
            HttpContext.Session.Remove("CurrentUser");
            GlobalClass.SessionValue = "None";
            GlobalClass.IsAutorized = false;

            GlobalClass.UserId = 0;
            GlobalClass.Login = "None";
            GlobalClass.Password = "None";
            GlobalClass.FIO = "None";
            GlobalClass.Email = "None";
            GlobalClass.PhoneNumber = "None";
            GlobalClass.Photo = "None";

            return RedirectToAction("Index", "Home"); 
        }


    }
}
