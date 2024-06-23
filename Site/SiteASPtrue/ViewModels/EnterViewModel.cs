using System.ComponentModel.DataAnnotations;

namespace SiteASP.ViewModels
{
    public class EnterViewModel
    {
        [Display(Name = "Введите логин:")]
        [Required(ErrorMessage = "Вам нужно ввести логин")]
        public string? Login { get; set; }
        [Display(Name = "Введите пароль:")]
        [Required(ErrorMessage = "Вам нужно ввести пароль")]
        public string? Password { get; set; }
    }
}
