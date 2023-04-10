using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.OrderAddressViewModels
{
    public class CreateOrderAddressViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Country { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }



    }
}
