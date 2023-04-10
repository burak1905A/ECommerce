using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Models.BrandViewModels
{
    public class BrandViewModel
    {
        public BrandViewModel()
        {
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

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

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
