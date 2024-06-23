using SiteASP.Models;

namespace SiteASP.Interfaces
{
    public interface IAllReviews
    {
        // вывод всех товаров
        IEnumerable<Reviews> Reviews { get; }
        Reviews getObjectServices(int ID);
    }
}
