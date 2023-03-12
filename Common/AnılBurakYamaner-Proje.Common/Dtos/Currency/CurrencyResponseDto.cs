using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Currency
{
    public class CurrencyResponseDto : BaseDto
    {
        public CurrencyResponseDto()
        {
            Products = new HashSet<ProductResponseDto>();
        }
        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }

        public ICollection<ProductResponseDto> Products { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
