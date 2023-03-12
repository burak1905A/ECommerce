﻿using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.Country;
using AnılBurakYamaner_Proje.Common.Dtos.CurrentAccount;
using AnılBurakYamaner_Proje.Common.Dtos.Location;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using AnılBurakYamaner_Proje.Common.Dtos.ProductComment;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Member
{
    public class MemberResponseDto : BaseDto
    {
        public MemberResponseDto()
        {
            ProductComments = new HashSet<ProductCommentResponseDto>();

            Orders = new HashSet<OrderResponseDto>();


            CurrentAccounts = new HashSet<CurrentAccountResponseDto>();
        }
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
        public CountryResponseDto Country { get; set; }

        public Guid LocationId { get; set; }
        public LocationResponseDto Location { get; set; }

        public ICollection<ProductCommentResponseDto> ProductComments { get; set; }

        public ICollection<OrderResponseDto> Orders { get; set; }

        

        public ICollection<CurrentAccountResponseDto> CurrentAccounts { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
