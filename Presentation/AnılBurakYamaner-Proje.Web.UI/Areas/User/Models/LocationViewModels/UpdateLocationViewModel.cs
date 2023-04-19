using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.LocationViewModels
{
    public class UpdateLocationViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
