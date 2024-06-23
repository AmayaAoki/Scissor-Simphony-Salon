using SiteASP.Models;

namespace SiteASP.Interfaces
{
    public interface IServicesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
