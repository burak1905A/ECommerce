using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductDetail
{
    public class ProductDetailResponseDto : BaseDto
    {
        public string Sku { get; set; }
        public string Details { get; set; }
        public string ExtraDetails { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
