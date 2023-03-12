using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? SortOrder { get; set; }
        public string İmageFile { get; set; }
        public int? DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public string CanonicalUrl { get; set; }


        public ICollection<ProductViewModel> Products { get; set; }

        public DateTime? CreatedDate { get; set; }
       
    }
}
