using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.User
{
    public class UserResponseDto : BaseDto
    {
        public UserResponseDto()
        {
            Products = new HashSet<ProductResponseDto>();

            Orders = new HashSet<OrderResponseDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }

        public bool IsAdmin { get; set; }
        public DateTime? LastLogin { get; set; }

        public DateTime? CreatedDate { get; set; }

        public GetAcceessTokenDto AcceessToken { get; set; }
        public ICollection<ProductResponseDto> Products { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }
    }
}
