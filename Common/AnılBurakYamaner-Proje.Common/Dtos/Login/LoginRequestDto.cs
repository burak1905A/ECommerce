using System.ComponentModel.DataAnnotations;

namespace AnılBurakYamaner_Proje.Common.Dtos.Login
{
    public class LoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
