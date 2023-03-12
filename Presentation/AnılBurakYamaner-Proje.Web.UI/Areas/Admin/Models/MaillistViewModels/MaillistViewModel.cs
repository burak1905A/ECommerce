using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.MaillistViewModels
{
    public class MaillistViewModel
    {
      
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatorIpAddress { get; set; }


        public DateTime? CreatedDate { get; set; }
    }
}
