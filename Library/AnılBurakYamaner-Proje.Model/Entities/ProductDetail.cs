using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class ProductDetail : CoreEntity
    {
        public string Sku { get; set; }
        public string Details { get; set; }
        public string ExtraDetails { get; set; }

        public User CreatedUserProductDetail { get; set; }
        public User ModifiedUserProductDetail { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
