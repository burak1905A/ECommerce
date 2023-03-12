using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Town
{
    public class TownRequestDto : BaseDto
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
      
    }
}
