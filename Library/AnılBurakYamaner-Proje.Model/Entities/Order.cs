using AnılBurakYamaner_Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
          

            OrderItems = new HashSet<OrderItem>();

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

        public User CreatedUserOrder { get; set; }
        public User ModifiedUserOrder{ get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }

   

        public ICollection<OrderItem> OrderItems { get; set; }



    }
}
