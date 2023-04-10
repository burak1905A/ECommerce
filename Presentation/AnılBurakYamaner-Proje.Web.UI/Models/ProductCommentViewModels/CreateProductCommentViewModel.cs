using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.ProductCommentViewModels
{
    public class CreateProductCommentViewModel
    {
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
