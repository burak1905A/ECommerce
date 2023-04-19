using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CurrencyViewModels
{
    public class CurrencyViewModel
    {
        public CurrencyViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
