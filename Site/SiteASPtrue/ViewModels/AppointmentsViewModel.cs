using SiteASP.Models;

namespace SiteASP.ViewModels
{
    public class AppointmentsViewModel
    {
        public IEnumerable<Appointments>? AllAppointments { get; set; }
        public string? CurrentFilter { get; set; }
        public IEnumerable<Services>? AllServices { get; set; }
    }
}
