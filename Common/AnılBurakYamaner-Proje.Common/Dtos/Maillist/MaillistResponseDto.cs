using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Maillist
{
    public class MaillistResponseDto : BaseDto
    {
        public MaillistResponseDto()
        {
            Orders = new HashSet<OrderResponseDto>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
