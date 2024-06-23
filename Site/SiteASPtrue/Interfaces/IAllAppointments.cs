using SiteASP.Models;

namespace SiteASP.Interfaces
{
    public interface IAllAppointments
    {
        // вывод всех товаров
        IEnumerable<Appointments> Appointments { get; }
        Appointments getObjectServices(int ID);
    }
}
