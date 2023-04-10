using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IUserApi
    {
        [Get("/user")]
        Task<ApiResponse<WebApiResponse<List<UserResponseDto>>>> List();

        [Get("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Get(Guid id);

        [Post("/user")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Post(UserRequestDto request);

        [Put("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Put(Guid id, UserRequestDto request);

        [Delete("/user/{id}")]
        Task<ApiResponse<WebApiResponse<UserResponseDto>>> Delete(Guid id);

        [Get("/user/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);


		[Get("/user/exists/{email}")]
		Task<ApiResponse<WebApiResponse<bool>>> ExistsUser(string email);

		[Get("/user/getactive")]
        Task<ApiResponse<WebApiResponse<List<UserResponseDto>>>> GetActive();
    }
}
