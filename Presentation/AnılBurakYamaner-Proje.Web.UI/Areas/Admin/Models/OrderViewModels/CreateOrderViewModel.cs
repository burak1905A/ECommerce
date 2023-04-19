using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string CustomerFirstname { get; set; }
        [Required]
        public string CustomerSurname { get; set; }
        [Required]
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

        public Guid ShippingAddressId { get; set; }
        public Guid UserId { get; set; }


    }
}
