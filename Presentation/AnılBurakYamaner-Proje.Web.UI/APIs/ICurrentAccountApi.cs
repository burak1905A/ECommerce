using AnılBurakYamaner_Proje.Common.Dtos.CurrentAccount;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICurrentAccountApi
    {
        [Get("/currentAccount")]
        Task<ApiResponse<WebApiResponse<List<CurrentAccountResponseDto>>>> List();

        [Get("/currentAccount/{id}")]
        Task<ApiResponse<WebApiResponse<CurrentAccountResponseDto>>> Get(Guid id);

        [Post("/currentAccount")]
        Task<ApiResponse<WebApiResponse<CurrentAccountResponseDto>>> Post(CurrentAccountRequestDto request);

        [Put("/currentAccount/{id}")]
        Task<ApiResponse<WebApiResponse<CurrentAccountResponseDto>>> Put(Guid id, CurrentAccountRequestDto request);

        [Delete("/currentAccount/{id}")]
        Task<ApiResponse<WebApiResponse<CurrentAccountResponseDto>>> Delete(Guid id);

        [Get("/currentAccount/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/currentAccount/getactive")]
        Task<ApiResponse<WebApiResponse<List<CurrentAccountResponseDto>>>> GetActive();
    }
}
