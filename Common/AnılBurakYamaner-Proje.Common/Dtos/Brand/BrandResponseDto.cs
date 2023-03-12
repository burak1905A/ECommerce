using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Brand
{
    public class BrandResponseDto : BaseDto
    {
        public BrandResponseDto()
        {
            Products = new HashSet<ProductResponseDto>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? SortOrder { get; set; }
        public string DistributorCode { get; set; }
        public string Distributor { get; set; }
        public string İmageFile { get; set; }
        public string ShowcaseContent { get; set; }
        public string DisplayShowcaseContent { get; set; }
        public string PageTitle { get; set; }
        public string Attachment { get; set; }

        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }
    }
}
