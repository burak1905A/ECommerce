using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.CurrentAccount
{
    public class CurrentAccountResponseDto : BaseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Balance { get; set; }
        public int? RiskLimit { get; set; }


        public Guid MemberId { get; set; }
        public MemberResponseDto Member { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
