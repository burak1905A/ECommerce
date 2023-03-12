using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Cart : CoreEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public string SessionId { get; set; }
        public bool? Locked { get; set; }

        public User CreatedUserCart { get; set; }
        public User ModifiedUserCart { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
