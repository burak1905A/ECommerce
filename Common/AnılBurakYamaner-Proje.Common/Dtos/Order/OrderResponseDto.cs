using AnılBurakYamaner_Proje.Common.Dtos.Base;
using AnılBurakYamaner_Proje.Common.Dtos.Maillist;
using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Dtos.OrderAddress;
using AnılBurakYamaner_Proje.Common.Dtos.OrderDetail;
using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Common.Dtos.Order
{
    public class OrderResponseDto : BaseDto
    {
        public OrderResponseDto()
        {
       

            OrderItems = new HashSet<OrderItemResponseDto>();

        }
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentProviderCode { get; set; }
        public string PaymentProviderName { get; set; }
        public string PaymentGatewayCode { get; set; }
        public string PaymentGatewayName { get; set; }
        public string BankName { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string Currency { get; set; }
        public int? Amount { get; set; }
        public int? TaxAmount { get; set; }
        public int? GeneralAmount { get; set; }
        public int? ShippingAmount { get; set; }
        public int? AdditionalServiceAmount { get; set; }
        public int? FinalAmount { get; set; }
        public int? İnstallment { get; set; }
        public int? İnstallmentRate { get; set; }
        public int? ExtraInstallment { get; set; }
        public string TransactionId { get; set; }
        public bool? HasUserNote { get; set; }
        public bool? PaymentStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string Referrer { get; set; }
        public int? İnvoicePrintCount { get; set; }
        public bool? UseGiftPackage { get; set; }
        public string GiftNote { get; set; }
        public bool? UsePromotion { get; set; }
        public string ShippingProviderCode { get; set; }
        public string ShippingProviderName { get; set; }
        public string ShippingCompanyName { get; set; }
        public bool? ShippingPaymentType { get; set; }
        public string ShippingTrackingCode { get; set; }
        public string Source { get; set; }

  

        public Guid UserId { get; set; }
        public UserResponseDto User { get; set; }

        public Guid ShippingAddressId { get; set; }
        public ShippingAddressResponseDto ShippingAddress { get; set; }

        

        public ICollection<OrderItemResponseDto> OrderItems { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
