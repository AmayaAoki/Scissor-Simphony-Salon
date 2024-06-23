using SiteASP.Models;

namespace SiteASP.ViewModels
{
    public class ServicesListViewModel
    {
        public IEnumerable<Services>? AllServices {  get; set; }
        public string? servvCategory { get; set; }
    }
}
