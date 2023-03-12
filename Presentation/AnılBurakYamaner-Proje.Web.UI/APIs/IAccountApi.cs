using AnılBurakYamaner_Proje.Common.Dtos.Login;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IAccountApi
    {
        [Get("/account")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Login(LoginRequestDto request);

        [Get("/account/refreshtoken")]
        Task<ApiResponse<WebApiResponse<GetAcceessTokenDto>>> RefreshToken(RefreshToken request);
    }
}
