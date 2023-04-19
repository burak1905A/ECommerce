using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductDetailViewModels
{
    public class CreateProductDetailViewModel
    {
        public Status Status { get; set; }
        public string Sku { get; set; }
        [Required]
        public string Details { get; set; }
        public string ExtraDetails { get; set; }

        public Guid ProductId { get; set; }

    }
}
