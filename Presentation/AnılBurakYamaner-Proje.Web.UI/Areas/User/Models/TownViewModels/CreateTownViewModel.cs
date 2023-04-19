using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.TownViewModels
{
    public class CreateTownViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid LocationId { get; set; }
    }
}
