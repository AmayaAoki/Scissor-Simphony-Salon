using System.ComponentModel.DataAnnotations;

namespace SiteASP.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public string? EmployeeID { get; set; }
        public string UserID { get; set; } = GlobalClass.FIO ?? string.Empty;
        public string? ServiceID { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Поле 'Дата' обязательно для заполнения.")]
        [RegularExpression(@"^((?!0001-01-01).)*$", ErrorMessage = "Выберите дату, которая не предшествует завтрашнему числу.")]
        public DateTime? Date { get; set; }
        public TimeSpan EventTime { get; set; }
        public string? Status { get; set; }
    }
    
}
