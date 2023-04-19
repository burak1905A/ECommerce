using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CountryViewModels
{
    public class CreateCountryViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
