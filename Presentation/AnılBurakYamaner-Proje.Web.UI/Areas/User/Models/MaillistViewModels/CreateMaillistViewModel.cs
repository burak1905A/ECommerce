using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.MaillistViewModels
{
    public class CreateMaillistViewModel
    {

        public Status Status { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }
    }
}
