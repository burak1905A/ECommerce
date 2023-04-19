using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CurrencyViewModels
{
    public class CreateCurrencyViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }
    }
}
