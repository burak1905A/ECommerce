using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.TownViewModels
{
    public class UpdateTownViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid LocationId { get; set; }
    }
}
