using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MemberViewModels
{
    public class UpdateMemberViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        [Required]
        public string OtherLocation { get; set; }
        [Required]
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
        public Guid LocationId { get; set; }
    }
}
