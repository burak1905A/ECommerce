using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.MaillistViewModels
{
    public class UpdateMaillistViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }
    }
}
