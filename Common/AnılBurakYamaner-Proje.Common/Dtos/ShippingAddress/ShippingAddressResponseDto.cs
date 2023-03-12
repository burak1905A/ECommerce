using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress
{
    public class ShippingAddressResponseDto : BaseDto
    {
        public ShippingAddressResponseDto()
        {
            Orders = new HashSet<OrderResponseDto>();
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }

       
        public ICollection<OrderResponseDto> Orders { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
