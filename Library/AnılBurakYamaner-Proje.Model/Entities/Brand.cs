using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Brand : CoreEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
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
        public User CreatedUserBrand { get; set; }
        public User ModifiedUserBrand { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
