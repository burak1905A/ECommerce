﻿using AnılBurakYamaner_Proje.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.OrderDetailViewModels
{
    public class UpdateOrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string varKey { get; set; }
        public string varValue { get; set; }


    }
}
