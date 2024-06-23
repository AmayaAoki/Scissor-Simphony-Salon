using SiteASP.Interfaces;
using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public class EmployeeRepository : IAllEmployee
    {
        // получаем все объекты
        public IEnumerable<Employee> Employee => appDBContent.Employee;
        private readonly AppDBContent appDBContent;
        public EmployeeRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        // один объект, где id = serviceid
        public Employee getObjectServices(int ID)
        {
            // Получаем услугу по ее идентификатору
            var empp = appDBContent.Employee.FirstOrDefault(s => s.Id == ID);
            // Проверяем, что услуга была найдена
            if (empp != null)
            {
                // Обрабатываем данные услуги, например, выводим на консоль
                Console.WriteLine($"ID: {empp.Id}, Name: {empp.FIO}, Photo: {empp.Photo}");
                return empp;
            }
            else
            {
                Console.WriteLine("Услуга не найдена.");
                return new Employee();
            }
            
        }

    }
}
