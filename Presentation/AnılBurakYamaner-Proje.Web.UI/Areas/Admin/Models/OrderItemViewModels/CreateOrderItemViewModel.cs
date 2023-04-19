using AnılBurakYamaner_Proje.Common.Enums;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels
{
    public class CreateOrderItemViewModel
    {
        public Status Status { get; set; }

        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductPrice { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

    }
}
