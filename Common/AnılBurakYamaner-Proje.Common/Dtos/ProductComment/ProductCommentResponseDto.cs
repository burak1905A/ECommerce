using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductComment
{
    public class ProductCommentResponseDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Rank { get; set; }
        public string isAnonymous { get; set; }

        public Guid MemberId { get; set; }
        public MemberResponseDto Member { get; set; }

        public Guid ProductId { get; set; }
        public ProductResponseDto Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
