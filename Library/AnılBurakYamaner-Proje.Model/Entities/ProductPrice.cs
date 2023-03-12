using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class ProductPrice : CoreEntity
    {
        public int? Value { get; set; }
        public string Type { get; set; }

        public int? Price { get; set; }
        public User CreatedUserProductPrice { get; set; }
        public User ModifiedUserProductPrice { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
