using AnılBurakYamaner_Proje.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public string LastIPAddress { get; set; }
    }
}
