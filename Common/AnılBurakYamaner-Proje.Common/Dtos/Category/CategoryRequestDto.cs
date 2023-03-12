using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Category
{
    public class CategoryRequestDto : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? SortOrder { get; set; }
        public string İmageFile { get; set; }
        public int? DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public string CanonicalUrl { get; set; }
    }
}
