using System.Collections.Generic;
using System;
using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CurrentAccountViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CountryViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.LocationViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderViewModels;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {
            ProductComments = new HashSet<ProductCommentViewModel>();

            Orders = new HashSet<OrderViewModel>();

            Carts = new HashSet<CartViewModel>();

            CurrentAccounts = new HashSet<CurrentAccountViewModel>();
        }

        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string OtherLocation { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string TcId { get; set; }
        public string ZipCode { get; set; }
        public string TaxOffice { get; set; }
        public string LastMailSentDate { get; set; }
        public string District { get; set; }
        public string DeviceType { get; set; }
        public string DeviceInfo { get; set; }

        public Guid CountryId { get; set; }
        public CountryViewModel Country { get; set; }

        public Guid LocationId { get; set; }
        public LocationViewModel Location { get; set; }

        public ICollection<ProductCommentViewModel> ProductComments { get; set; }

        public ICollection<OrderViewModel> Orders { get; set; }

        public ICollection<CartViewModel> Carts { get; set; }

        public ICollection<CurrentAccountViewModel> CurrentAccounts { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
