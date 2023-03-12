using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductPrice
{
    public class ProductPriceResponseDto : BaseDto
    {
        public int? Value { get; set; }
        public string Type { get; set; }


        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
