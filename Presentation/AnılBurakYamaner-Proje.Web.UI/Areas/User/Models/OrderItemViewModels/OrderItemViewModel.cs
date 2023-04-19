using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.OrderViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.OrderItemViewModels
{
    public class OrderItemViewModel
    {

        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductPrice { get; set; }


        public Guid OrderId { get; set; }
        public OrderViewModel Order { get; set; }

        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
