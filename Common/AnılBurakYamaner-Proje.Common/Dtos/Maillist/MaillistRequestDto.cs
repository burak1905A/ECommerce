using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Maillist
{
    public class MaillistRequestDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }
    }
}
