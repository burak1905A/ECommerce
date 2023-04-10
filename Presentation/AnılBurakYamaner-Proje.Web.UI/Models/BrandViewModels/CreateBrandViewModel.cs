using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.BrandViewModels
{
    public class CreateBrandViewModel
    {
        public Status Status { get; set; }

        [Required]
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
    }
}
