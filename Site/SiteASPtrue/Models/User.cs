using System.ComponentModel.DataAnnotations;

namespace SiteASP.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Логин обязателен")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        public string? Password { get; set; }
        public string? FIO { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Photo { get; set; }

    }
}
