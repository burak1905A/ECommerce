using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Base
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
