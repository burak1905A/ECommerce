using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartItemViewModels
{
    public class CreateCartItemViewModel
    {
        public Status Status { get; set; }

        [Required]
        public int? ParentProductId { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }


        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }

    }
}
