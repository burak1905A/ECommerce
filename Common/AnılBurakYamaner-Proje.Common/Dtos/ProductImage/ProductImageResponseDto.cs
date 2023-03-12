using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductImage
{
    public class ProductImageResponseDto : BaseDto
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
