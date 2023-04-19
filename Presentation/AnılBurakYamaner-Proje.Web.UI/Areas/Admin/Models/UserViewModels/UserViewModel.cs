using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.OrderViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Products = new HashSet<ProductViewModel>();

            Orders = new HashSet<OrderViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAddress { get; set; }
        public DateTime? LastLogin { get; set; }

        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

        public ICollection<OrderViewModel> Orders { get; set; }
    }
}
