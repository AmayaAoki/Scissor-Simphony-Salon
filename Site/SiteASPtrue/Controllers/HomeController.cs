using Microsoft.AspNetCore.Mvc;
using SiteASP.Interfaces;
using SiteASP.Models;
using System.Diagnostics;

namespace SiteASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllServices _allServices;
        private readonly IServicesCategory _servicesCategory;
        private readonly IAllEmployee _allemployee;
        private readonly IAllAppointments _allAppointments;
        private readonly IAllReviews _allReviews;

        public HomeController(ILogger<HomeController> logger, IAllServices allServices, IServicesCategory servicesCategory, IAllEmployee allemployee, IAllAppointments allAppointments, IAllReviews allReviews)
        {
            _logger = logger;
            _allServices = allServices;
            _servicesCategory = servicesCategory;
            _allemployee = allemployee;
            _allAppointments = allAppointments;
            _allReviews = allReviews;
        }

        public IActionResult Index()
        {
            // получение данных из репозитория
            var services = _allServices.Services;
            var categories = _servicesCategory.AllCategories;
            var employee = _allemployee.Employee;
            var appointments = _allAppointments.Appointments;
            var reviews = _allReviews;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
