using SiteASP.Models;

namespace SiteASP.Interfaces
{
    public interface IAllEmployee
    {
        // вывод всех товаров
        IEnumerable<Employee> Employee { get; }
        Employee getObjectServices(int ID);
    }
}
