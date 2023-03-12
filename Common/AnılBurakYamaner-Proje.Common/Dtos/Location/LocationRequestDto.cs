using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Location
{
    public class LocationRequestDto : BaseDto
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        
    }
}
