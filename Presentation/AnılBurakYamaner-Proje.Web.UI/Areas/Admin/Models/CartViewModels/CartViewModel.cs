using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartItemViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new HashSet<CartItemViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid? SessionId { get; set; }
        public bool? Locked { get; set; }

        public Guid MemberId { get; set; }
        public MemberViewModel Member { get; set; }

        public ICollection<CartItemViewModel> CartItems { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
