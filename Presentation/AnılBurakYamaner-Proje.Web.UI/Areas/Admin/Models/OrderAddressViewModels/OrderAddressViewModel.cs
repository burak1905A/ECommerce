using AnılBurakYamaner_Proje.Common.Enums;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderAddressViewModels
{
    public class OrderAddressViewModel
    {
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


        public DateTime? CreatedDate { get; set; }
    }
}
