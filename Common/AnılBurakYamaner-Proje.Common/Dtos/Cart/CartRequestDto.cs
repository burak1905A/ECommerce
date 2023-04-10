using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Cart
{
    public class CartRequestDto : BaseDto
    {
        public Guid? SessionId { get; set; }
        public bool? Locked { get; set; }
        public Guid? UserId { get; set; }
       
    }
}
