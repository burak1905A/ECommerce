using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Town
{
    public class TownResponseDto : BaseDto
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }
        public LocationResponseDto Location { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
