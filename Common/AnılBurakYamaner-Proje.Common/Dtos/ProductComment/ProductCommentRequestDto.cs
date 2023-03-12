using AnılBurakYamaner_Proje.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.ProductComment
{
    public class ProductCommentRequestDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Rank { get; set; }
        public string isAnonymous { get; set; }
        public Guid MemberId { get; set; }
        public Guid ProductId { get; set; }
       
    }
}
