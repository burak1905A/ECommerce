using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Models.LocationViewModels;
using AnılBurakYamaner_Proje.Web.UI.Models.MemberViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Models.CountryViewModels
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Members = new HashSet<MemberViewModel>();

            Locations = new HashSet<LocationViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }


        public ICollection<MemberViewModel> Members { get; set; }

        public ICollection<LocationViewModel> Locations { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
