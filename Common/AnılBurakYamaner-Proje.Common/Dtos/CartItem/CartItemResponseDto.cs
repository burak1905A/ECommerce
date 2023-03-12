using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.CartItem
{
    public class CartItemResponseDto : BaseDto
    {
        public int? ParentProductId { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }

        public Guid CartId { get; set; }
        public CartResponseDto Cart { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
