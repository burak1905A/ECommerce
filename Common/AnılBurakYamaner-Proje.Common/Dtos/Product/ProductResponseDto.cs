using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Dtos.ProductComment;
using AnılBurakYamaner_Proje.Common.Dtos.ProductDetail;
using AnılBurakYamaner_Proje.Common.Dtos.ProductImage;
using AnılBurakYamaner_Proje.Common.Dtos.ProductPrice;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Common.Dtos.Product
{
    public class ProductResponseDto : BaseDto
    {
        public ProductResponseDto()
        {
            ProductPrices = new HashSet<ProductPriceResponseDto>();

            ProductImages = new HashSet<ProductImageResponseDto>();

            ProductDetails = new HashSet<ProductDetailResponseDto>();

            ProductComments = new HashSet<ProductCommentResponseDto>();

            OrderItems = new HashSet<OrderItemResponseDto>();

        }
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

        public string ProductPrice { get; set; }

        public string ProductDetail { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResponseDto Category { get; set; }

        public Guid BrandId { get; set; }
        public BrandResponseDto Brand { get; set; }


        public ICollection<ProductPriceResponseDto> ProductPrices { get; set; }

        public ICollection<ProductImageResponseDto> ProductImages { get; set; }

        public ICollection<ProductDetailResponseDto> ProductDetails { get; set; }

        public ICollection<ProductCommentResponseDto> ProductComments { get; set; }

        public ICollection<OrderItemResponseDto> OrderItems { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid UserId { get; set; }
        public UserResponseDto User { get; set; }
    }
}
