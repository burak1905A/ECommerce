using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Product
{
    public class ProductRequestDto : BaseDto
    {
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

        public string ProductPrice { get; set; }

        public string ProductDetail { get; set; }
        public string Gift { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
      
    }
}
