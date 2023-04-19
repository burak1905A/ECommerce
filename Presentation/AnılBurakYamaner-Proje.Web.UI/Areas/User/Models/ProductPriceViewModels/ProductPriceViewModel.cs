using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductPriceViewModels
{
    public class ProductPriceViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public int? Value { get; set; }
        public string Type { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
