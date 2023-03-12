using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class CreateCartViewModel
    {
        public Status Status { get; set; }
        [Required]
        public string SessionId { get; set; }
        public bool? Locked { get; set; }

        public Guid MemberId { get; set; }
        
    }
}
