using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class OrderItem : CoreEntity
    {
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductPrice { get; set; }

        public User CreatedUserOrderItem { get; set; }
        public User ModifiedUserOrderItem { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
