namespace AnılBurakYamaner_Proje.Common.Models
{
    public class GetAcceessTokenDto
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public long Expires { get; set; }
        public string RefreshToken { get; set; }
    }
}