using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.ProductPriceViewModels
{
    public class CreateProductPriceViewModel
    {
        public Status Status { get; set; }
        [Required]
        public int? Value { get; set; }
        public string Type { get; set; }

        public Guid ProductId { get; set; }

    }
}
