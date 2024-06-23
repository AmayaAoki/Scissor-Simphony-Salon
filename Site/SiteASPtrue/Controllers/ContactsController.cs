using Microsoft.AspNetCore.Mvc;
using SiteASP.Data;
using SiteASP.Models;

namespace SiteASP.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDBContent _db;
        public ContactsController(AppDBContent db)
        {
            _db = db;
        }

        public IActionResult Index() 
        {
            // Проверяем, авторизован ли пользователь
            if (GlobalClass.IsAutorized)
            {
                // Если пользователь авторизован, заполняем поле UserEmail его email
                var contact = new Contact { UserEmail = GlobalClass.Email };
                return View(contact);
            }
            // Если пользователь не авторизован, просто отображаем пустую форму
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contact contact) // проверка данных из формы
        {
            // Проверяем наличие знаков @ и точки в UserEmail
            if (!IsValidEmail(contact.UserEmail))
            {
                ModelState.AddModelError("UserEmail", "Неверный формат адреса электронной почты.");
            }
            if (ModelState.IsValid)
            {
                // Сохраняем данные в базу данных
                _db.Contact.Add(contact);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Ваше сообщение отправлено! Ответ будет прислан на Вашу электронную почту в течении нескольких дней.";

                return RedirectToAction("Index", contact);
            }
            return View("Index", contact);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains(".") && email.Contains("@");
            }
            catch
            {
                return false;
            }
        }
    }
}
