using AnılBurakYamaner_Proje.Common.Enums;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderDetailViewModels
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string varKey { get; set; }
        public string varValue { get; set; }


        public DateTime? CreatedDate { get; set; }
    }
}
