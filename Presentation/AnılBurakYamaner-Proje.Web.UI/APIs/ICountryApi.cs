using AnılBurakYamaner_Proje.Common.Dtos.Country;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICountryApi
    {
        [Get("/country")]
        Task<ApiResponse<WebApiResponse<List<CountryResponseDto>>>> List();

        [Get("/country/{id}")]
        Task<ApiResponse<WebApiResponse<CountryResponseDto>>> Get(Guid id);

        [Post("/country")]
        Task<ApiResponse<WebApiResponse<CountryResponseDto>>> Post(CountryRequestDto request);

        [Put("/country/{id}")]
        Task<ApiResponse<WebApiResponse<CountryResponseDto>>> Put(Guid id, CountryRequestDto request);

        [Delete("/country/{id}")]
        Task<ApiResponse<WebApiResponse<CountryResponseDto>>> Delete(Guid id);

        [Get("/country/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/country/getactive")]
        Task<ApiResponse<WebApiResponse<List<CountryResponseDto>>>> GetActive();


    }
}
