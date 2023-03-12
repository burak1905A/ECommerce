using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Member : CoreEntity
    {
        public Member()
        {
            ProductComments = new HashSet<ProductComment>();

            CurrentAccounts =  new HashSet<CurrentAccount>();
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool? Gender  { get; set; }
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

        public User CreatedUserMember { get; set; }
        public User ModifiedUserMember { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }

        public ICollection<CurrentAccount> CurrentAccounts { get; set; }
    }
}
