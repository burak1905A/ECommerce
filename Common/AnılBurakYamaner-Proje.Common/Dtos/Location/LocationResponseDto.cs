using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Country;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Dtos.Town;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Location
{
    public class LocationResponseDto : BaseDto
    {
        public LocationResponseDto()
        {
            Members = new HashSet<MemberResponseDto>();

            Towns = new HashSet<TownResponseDto>();
        }
        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public CountryResponseDto Country { get; set; }

        public ICollection<MemberResponseDto> Members { get; set; }

        public ICollection<TownResponseDto> Towns { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
