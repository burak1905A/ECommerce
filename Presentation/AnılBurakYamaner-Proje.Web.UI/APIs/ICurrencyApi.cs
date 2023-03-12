using AnılBurakYamaner_Proje.Common.Dtos.Currency;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICurrencyApi
    {
        [Get("/currency")]
        Task<ApiResponse<WebApiResponse<List<CurrencyResponseDto>>>> List();

        [Get("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponseDto>>> Get(Guid id);

        [Post("/currency")]
        Task<ApiResponse<WebApiResponse<CurrencyResponseDto>>> Post(CurrencyRequestDto request);

        [Put("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponseDto>>> Put(Guid id, CurrencyRequestDto request);

        [Delete("/currency/{id}")]
        Task<ApiResponse<WebApiResponse<CurrencyResponseDto>>> Delete(Guid id);

        [Get("/currency/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/currency/getactive")]
        Task<ApiResponse<WebApiResponse<List<CurrencyResponseDto>>>> GetActive();
    }
}
