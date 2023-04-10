using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Models.LocationViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Models.TownViewModels
{
    public class TownViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Name { get; set; }

        public Guid LocationId { get; set; }
        public LocationViewModel Location { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
