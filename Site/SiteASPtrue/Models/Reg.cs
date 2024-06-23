using SiteASP;
using System.ComponentModel.DataAnnotations;

namespace SiteASP.Models
{
    public class Reg
    {
        [Display(Name = "Введите логин:")]
        [Required(ErrorMessage = "Вам нужно ввести логин")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Логин должен содержать только латинские буквы и цифры")]
        public string? Login { get; set; }

        [Display(Name = "Введите пароль:")]
        [Required(ErrorMessage = "Вам нужно ввести пароль")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Пароль должен содержать только латинские буквы и цифры")]
        public string? Password { get; set; }

        [Display(Name = "Введите ФИО:")]
        [Required(ErrorMessage = "Вам нужно ввести ФИО")]
        [RegularExpression(@"^([А-Яа-я]+\s){1,2}[А-Яа-я]+$", ErrorMessage = "ФИО должно содержать один или два пробела между словами")]
        public string? FIO { get; set; }

        [Display(Name = "Введите почту:")]
        [Required(ErrorMessage = "Вам нужно ввести почту")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Почта должна содержать доменное имя")]
        public string? Email { get; set; }

        [Display(Name = "Введите номер телефона:")]
        [Required(ErrorMessage = "Вам нужно ввести телефон")]
        [RegularExpression(@"^\+7\d{10}$", ErrorMessage = "Телефон должен начинаться с +7 и содержать 10 цифр после")]
        public string? Phone { get; set; }

        [Display(Name = "Выберите фотографию:")]
        [Required(ErrorMessage = "Вам нужно выбрать фотографию")]
        public string? Photo { get; set; }
    }
}
