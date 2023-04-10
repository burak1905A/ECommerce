using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        public Status Status { get; set; }
        public string Name { get; set; }
    }
}
