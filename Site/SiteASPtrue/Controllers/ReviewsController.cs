using Microsoft.AspNetCore.Mvc;
using SiteASP.Data;
using SiteASP.Interfaces;
using SiteASP.Models;
using SiteASP.ViewModels;

namespace SiteASP.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IAllReviews _allemp;
        private readonly AppDBContent _db;
        // Используем конструктор для внедрения зависимости IAllReviews
        public ReviewsController(AppDBContent db, IAllReviews allReviews)
        {
            _db = db;
            _allemp = allReviews;
        }
        // Метод для отображения списка сотрудников
        public IActionResult Index()
        {
            // Создаем объект модели ReviewsViewModel
            var viewModel = new ReviewsViewModel
            {
                // Получаем список всех отзывов, где Checked = true
                AllReviews = _allemp.Reviews.Where(review => review.Checked)
            };
            
            return View(viewModel);
        }
        
        public IActionResult CreateReview()
        {
            if (string.IsNullOrEmpty(GlobalClass.FIO) || GlobalClass.FIO == "None")
            {
                return RedirectToAction("Index", "Enter");
            }
            return View("CreateReview");
        }

        [HttpPost]
        public async Task<IActionResult> Check(Reviews reviews)
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalClass.FIO) || GlobalClass.FIO == "None")
                {
                    // Если пользователь не авторизован, перенаправляем на страницу авторизации
                    return RedirectToAction("Index", "Enter");
                }
                reviews.UserName = GlobalClass.FIO;
                reviews.UserPhoto = GlobalClass.Photo ?? string.Empty;
                reviews.Checked = false;
                _db.Reviews.Add(reviews);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Отзыв отправлен!";

                return RedirectToAction("CreateReview", "Reviews");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                // Если есть внутреннее исключение, выведем его тоже
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                    Console.WriteLine("Inner Exception Stack Trace: " + ex.InnerException.StackTrace);
                }
            }
            
            return View("Index", reviews);
        }

    }
}
