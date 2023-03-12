using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class OrderDetail : CoreEntity
    {
        public string varKey { get; set; }
        public string varValue { get; set; }

        public User CreatedUserOrderDetail { get; set; }
        public User ModifiedUserOrderDetail { get; set; }

      
    }
}
