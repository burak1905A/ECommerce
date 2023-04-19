using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.BrandViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductPriceViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductPrices = new HashSet<ProductPriceViewModel>();

            ProductImages = new HashSet<ProductImageViewModel>();

            ProductDetails = new HashSet<ProductDetailViewModel>();

            ProductComments = new HashSet<ProductCommentViewModel>();

            OrderItems = new HashSet<OrderItemViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }

        public string FullName { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int? Price1 { get; set; }
        public int? Warranty { get; set; }
        public string Tax { get; set; }
        public int? StockAmount { get; set; }
        public int? Discount { get; set; }
        public string isGifted { get; set; }
        public string Gift { get; set; }

        public string ProductDetail { get; set; }
        public int? ProductPrice { get; set; }

        public int Quantity { get; set; } = 1;

        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }

        public Guid BrandId { get; set; }
        public BrandViewModel Brand { get; set; }

        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }

        public ICollection<ProductPriceViewModel> ProductPrices { get; set; }

        public ICollection<ProductImageViewModel> ProductImages { get; set; }

        public ICollection<ProductDetailViewModel> ProductDetails { get; set; }

        public ICollection<ProductCommentViewModel> ProductComments { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
