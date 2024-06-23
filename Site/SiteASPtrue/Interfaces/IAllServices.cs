using SiteASP.Models;

namespace SiteASP.Interfaces
{
    public interface IAllServices
    {
        // вывод всех товаров
        IEnumerable<Services> Services { get; }
        Services getObjectServices(int ServiceID);
    }
}
