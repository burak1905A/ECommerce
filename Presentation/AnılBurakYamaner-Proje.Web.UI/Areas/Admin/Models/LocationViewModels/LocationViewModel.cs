using System.Collections.Generic;
using System;
using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CountryViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.TownViewModels;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.LocationViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            Members = new HashSet<MemberViewModel>();

            Towns = new HashSet<TownViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public CountryViewModel Country { get; set; }

        public ICollection<MemberViewModel> Members { get; set; }

        public ICollection<TownViewModel> Towns { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
