using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Currency : CoreEntity
    {
        public Currency()
        {
            Products = new HashSet<Product>();
        }
        public string Label { get; set; }
        public int? BuyingPrice { get; set; }
        public int? SellingPrice { get; set; }
        public string abb { get; set; }
        public bool? İsPrimary { get; set; }

        public User CreatedUserCurrency { get; set; }
        public User ModifiedUserCurrency { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
