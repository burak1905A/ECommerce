using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.CartItem
{
    public class CartItemRequestDto : BaseDto
    {
        public int? ParentProductId { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
               
        public Guid CartId { get; set; }
        
        public Guid ProductId { get; set; }
        

    }
}
