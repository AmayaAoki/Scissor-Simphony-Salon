using System.ComponentModel.DataAnnotations;

namespace SiteASP.Models
{
    public class Employee
    {
      // Указываем, что это первичный ключ
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FIO { get; set; }
        public string? Photo { get; set; }
    }
}
