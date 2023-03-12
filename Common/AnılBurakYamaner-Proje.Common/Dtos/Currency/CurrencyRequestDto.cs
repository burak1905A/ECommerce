using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Currency
{
    public class CurrencyRequestDto : BaseDto
    {
        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }
    }
}
