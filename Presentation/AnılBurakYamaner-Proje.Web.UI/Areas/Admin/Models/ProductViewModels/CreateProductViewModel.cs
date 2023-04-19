using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class CreateProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Sku { get; set; }
        [Required]
        public string Barcode { get; set; }
        public int? Price1 { get; set; }
        public int? Warranty { get; set; }
        public string Tax { get; set; }
        public int? StockAmount { get; set; }
        public int? Discount { get; set; }
        public string isGifted { get; set; }
        public string Gift { get; set; }

        public string ProductDetail { get; set; }
        public int? ProductPrice { get; set; }
        public Guid CategoryId { get; set; }

        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
    }
}
