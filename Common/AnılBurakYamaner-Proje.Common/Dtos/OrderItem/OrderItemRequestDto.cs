using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.OrderItem
{
    public class OrderItemRequestDto : BaseDto
    {

        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductPrice { get; set; }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
