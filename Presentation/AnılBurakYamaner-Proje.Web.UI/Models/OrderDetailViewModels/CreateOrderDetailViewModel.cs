using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Models.OrderDetailViewModels
{
    public class CreateOrderDetailViewModel
    {
        public Status Status { get; set; }

        [Required]
        public string varKey { get; set; }
        public string varValue { get; set; }


    }
}
