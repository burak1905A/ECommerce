using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.MemberViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductCommentViewModels
{
    public class ProductCommentViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int? Rank { get; set; }
        public string isAnonymous { get; set; }


        public Guid MemberId { get; set; }
        public MemberViewModel Member { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
