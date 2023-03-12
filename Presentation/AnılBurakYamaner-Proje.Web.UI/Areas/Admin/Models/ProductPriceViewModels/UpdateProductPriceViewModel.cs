using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductPriceViewModels
{
    public class UpdateProductPriceViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required]
        public int? Value { get; set; }
        public string Type { get; set; }

        public Guid ProductId { get; set; }
    }
}
