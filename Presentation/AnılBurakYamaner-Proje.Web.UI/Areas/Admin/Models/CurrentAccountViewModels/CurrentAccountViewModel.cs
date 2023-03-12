using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CurrentAccountViewModels
{
    public class CurrentAccountViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public int? Balance { get; set; }
        public int? RiskLimit { get; set; }

        public Guid MemberId { get; set; }
        public MemberViewModel Member { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
