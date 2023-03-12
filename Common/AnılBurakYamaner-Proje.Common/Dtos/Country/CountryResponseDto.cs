using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Location;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Country
{
    public class CountryResponseDto : BaseDto
    {
        public CountryResponseDto()
        {
            Members = new HashSet<MemberResponseDto>();

            Locations = new HashSet<LocationResponseDto>();
        }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<MemberResponseDto> Members { get; set; }

        public ICollection<LocationResponseDto> Locations { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
