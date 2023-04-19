using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.LocationViewModels
{
    public class CreateLocationViewModel
    {
        public Status Status { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}
