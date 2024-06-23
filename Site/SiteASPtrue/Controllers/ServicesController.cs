using Azure;
using Microsoft.AspNetCore.Mvc;
using SiteASP;
using SiteASP.Interfaces;
using SiteASP.Models;
using SiteASP.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System;

namespace SiteASP.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IAllServices _allServices;
        private readonly IServicesCategory _allCategories;
        // обращение к классу который реализует интерфейс
        public ServicesController(IAllServices iAllServices, IServicesCategory iServicesCat)
        {
            _allServices = iAllServices;
            _allCategories = iServicesCat;
        }
        public ViewResult List()
        {
            ServicesListViewModel obj = new ServicesListViewModel();
            obj.AllServices = _allServices.Services;

            return View(obj);
        }
        // Метод для обработки отправки данных о выбранной услуге
        [HttpPost]
        public IActionResult Save(string serviceName)
        {
            GlobalClass.ServiceName = serviceName;

            return RedirectToAction("Index", "Appointments");
        }

    }
}




