using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels
{
    public class ProductDetailViewModel
    {

        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Sku { get; set; }
        public string Details { get; set; }
        public string ExtraDetails { get; set; }

       
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
