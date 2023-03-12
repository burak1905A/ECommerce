using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductDetail
{
    public class ProductDetailRequestDto : BaseDto
    {
        public string Sku { get; set; }
        public string Details { get; set; }
        public string ExtraDetails { get; set; }
        public Guid ProductId { get; set; }
       
    }
}
