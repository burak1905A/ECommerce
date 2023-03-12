using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Category : CoreEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? SortOrder { get; set; }
        public string İmageFile { get; set; }
        public int? DisplayShowcaseContent { get; set; }
        public string ShowcaseContent { get; set; }
        public string CanonicalUrl { get; set; }

        public User CreatedUserCategory { get; set; }
        public User ModifiedUserCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
