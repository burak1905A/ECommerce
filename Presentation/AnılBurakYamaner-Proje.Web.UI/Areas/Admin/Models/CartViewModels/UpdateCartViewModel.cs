using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class UpdateCartViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required]
        public Guid? SessionId { get; set; }
        public bool? Locked { get; set; }

        public Guid MemberId { get; set; }
    }
}
