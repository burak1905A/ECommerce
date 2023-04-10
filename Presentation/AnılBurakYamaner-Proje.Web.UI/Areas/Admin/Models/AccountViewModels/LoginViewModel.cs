using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Posta adresi gereklidir..")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola gereklidir..")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
