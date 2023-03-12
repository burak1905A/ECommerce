using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartItemViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public int? ParentProductId { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }


        public Guid CartId { get; set; }
        public CartViewModel Cart { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
