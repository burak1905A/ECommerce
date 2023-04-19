using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductImageViewModels
{
    public class ProductImageViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string FileName { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
