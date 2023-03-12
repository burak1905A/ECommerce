using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductPrice
{
    public class ProductPriceRequestDto : BaseDto
    {
        public int? Value { get; set; }
        public string Type { get; set; }
        public Guid ProductId { get; set; }
       
    }
}
