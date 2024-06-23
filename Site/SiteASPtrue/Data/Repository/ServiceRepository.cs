using Microsoft.EntityFrameworkCore;
using SiteASP.Interfaces;
using SiteASP.Models;


namespace SiteASP.Data.Repository
{
    public class ServiceRepository : IAllServices
    {
        private readonly AppDBContent appDBContent;
        public ServiceRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        // получаем все объекты
        public IEnumerable<Services> Services => appDBContent.Service;
        // один объект, где id = serviceid
        public Services getObjectServices(int serviceId)
        {
            // Получаем услугу по ее идентификатору
            var service = appDBContent.Service.FirstOrDefault(s => s.Id == serviceId);
            // Проверяем, что услуга была найдена
            if (service != null)
            {
                // Обрабатываем данные услуги, например, выводим на консоль
                Console.WriteLine($"ID: {service.Id}, Name: {service.ProcedureName}, Description: {(service.Description ?? "No description")}");
                return service;
            }
            else
            {
                Console.WriteLine("Услуга не найдена");
                return new Services();
            }
            
        }
    }
}
