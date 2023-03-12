using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CurrentAccountViewModels
{
    public class CreateCurrentAccountViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public int? Balance { get; set; }
        public int? RiskLimit { get; set; }

        public Guid MemberId { get; set; }
    }
}
