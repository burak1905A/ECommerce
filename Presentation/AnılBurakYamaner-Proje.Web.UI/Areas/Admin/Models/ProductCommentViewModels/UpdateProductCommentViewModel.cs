using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels
{
    public class UpdateProductCommentViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Rank { get; set; }
        public string isAnonymous { get; set; }

        public Guid MemberId { get; set; }

        public Guid ProductId { get; set; }
    }
}
