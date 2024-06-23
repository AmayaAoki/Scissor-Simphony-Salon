using SiteASP.Interfaces;
using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public class AppointmentsRepository : IAllAppointments
    {
        // получаем все объекты
        private readonly AppDBContent _appDBContent;
        public AppointmentsRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public IEnumerable<Appointments> Appointments => _appDBContent.Appointments;
        // один объект, где id = serviceid
        public Appointments getObjectServices(int ID)
        {
            // Получаем запись по ее идентификатору
            var record = _appDBContent.Appointments.FirstOrDefault(r => r.Id == ID);
            // Проверяем, что запись была найдена
            if (record != null)
            {
                // Обрабатываем данные записи, например, выводим на консоль
                Console.WriteLine($"ID: {record.Id}, EmployeeID: {record.EmployeeID}, ServiceID: {record.ServiceID}");
                return record;
            }
            else
            {
                Console.WriteLine("Запись не найдена");
                return new Appointments();
            }

            
        }


    }
}
