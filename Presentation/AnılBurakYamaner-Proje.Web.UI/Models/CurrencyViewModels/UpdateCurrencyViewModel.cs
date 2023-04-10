using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.CurrencyViewModels
{
    public class UpdateCurrencyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }
    }
}
