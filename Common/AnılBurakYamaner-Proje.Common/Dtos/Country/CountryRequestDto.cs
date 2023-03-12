using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Country
{
    public class CountryRequestDto : BaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
