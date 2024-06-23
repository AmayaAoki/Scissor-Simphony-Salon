using System.ComponentModel.DataAnnotations;

namespace SiteASP.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Display(Name = "Введите почту:")]
        [Required(ErrorMessage = "Вам нужно ввести верную почту")]
        public string? UserEmail { get; set; }
        [Display(Name = "Введите ваше сообщение:")]
        public string? Text { get; set; }

    }
}
