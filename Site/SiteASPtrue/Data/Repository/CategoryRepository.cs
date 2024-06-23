using SiteASP.Interfaces;
using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public class CategoryRepository : IServicesCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
