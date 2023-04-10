using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim Gereklidir..")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim gereklidir..")]
        [Display(Name = "Soy İsim")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "E-Posta adresi gereklidir..")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola gereklidir..")]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifre eşleşmedi,Tekrar deneyiniz... !")]
        public string ConfirmPassword { get; set; }
    }
}
