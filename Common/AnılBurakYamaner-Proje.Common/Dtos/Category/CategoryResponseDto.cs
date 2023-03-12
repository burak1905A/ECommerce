using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Dtos.ProductComment;
using AnılBurakYamaner_Proje.Common.Dtos.ProductImage;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Category
{
    public class CategoryResponseDto : BaseDto
    {
        public CategoryResponseDto()
        {
            Products = new HashSet<ProductResponseDto>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? SortOrder { get; set; }
        public string İmageFile { get; set; }
        public int? DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public string CanonicalUrl { get; set; }

        public ICollection<ProductResponseDto> Products { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
