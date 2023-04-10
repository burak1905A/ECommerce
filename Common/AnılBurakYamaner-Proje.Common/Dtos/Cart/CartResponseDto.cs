using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Cart
{
    public class CartResponseDto : BaseDto
    {
        public CartResponseDto()
        {
            CartItems = new HashSet<CartItemResponseDto>();
        }
        public Guid? SessionId { get; set; }
        public bool? Locked { get; set; }

        public Guid? UserId { get; set; }
        public UserResponseDto User { get; set; }

        public ICollection<CartItemResponseDto> CartItems { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
