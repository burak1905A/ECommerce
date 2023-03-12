using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.OrderDetail
{
    public class OrderDetailResponseDto : BaseDto
    {
        public string varKey { get; set; }
        public string varValue { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
