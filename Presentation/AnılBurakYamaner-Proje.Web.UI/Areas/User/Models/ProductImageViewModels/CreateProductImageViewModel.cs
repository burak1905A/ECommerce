using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductImageViewModels
{
    public class CreateProductImageViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string FileName { get; set; }
        public string Extension { get; set; }
        [Required]
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }

        public Guid ProductId { get; set; }

    }
}
