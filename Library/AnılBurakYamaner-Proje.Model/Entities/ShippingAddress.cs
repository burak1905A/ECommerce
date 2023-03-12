using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class ShippingAddress : CoreEntity
    {
        public ShippingAddress()
        {
            Orders = new HashSet<Order>();
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

        public User CreatedUserShippingAddress{ get; set; }
        public User ModifiedUserShippingAddress { get; set; }

        

        public ICollection<Order> Orders { get; set; }
    }
}
