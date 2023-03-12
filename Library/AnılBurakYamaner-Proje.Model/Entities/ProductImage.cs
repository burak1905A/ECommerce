using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class ProductImage : CoreEntity
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public string Revision { get; set; }
        public int? SortOrder { get; set; }

        public User CreatedUserProductImage { get; set; }
        public User ModifiedUserProductImage { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }    
    }
}
