﻿using System.Collections.Generic;
using System;
using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartItemViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.OrderViewModels;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ShippingAddressViewModels
{
    public class CheckOutViewModel
    {

        public CheckOutViewModel()
        {
            Orders = new HashSet<OrderViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }



        public ICollection<OrderViewModel> Orders { get; set; }

        public DateTime? CreatedDate { get; set; }
        public List<CartItemViewModel> CartItems { get; internal set; }
    }
}
