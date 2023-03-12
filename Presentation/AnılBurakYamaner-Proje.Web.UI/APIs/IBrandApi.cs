using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IBrandApi
    {
        [Get("/brand")]
        Task<ApiResponse<WebApiResponse<List<BrandResponseDto>>>> List();

        [Get("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponseDto>>> Get(Guid id);

        [Post("/brand")]
        Task<ApiResponse<WebApiResponse<BrandResponseDto>>> Post(BrandRequestDto request);

        [Put("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponseDto>>> Put(Guid id, BrandRequestDto request);

        [Delete("/brand/{id}")]
        Task<ApiResponse<WebApiResponse<BrandResponseDto>>> Delete(Guid id);

        [Get("/brand/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/brand/getactive")]
        Task<ApiResponse<WebApiResponse<List<BrandResponseDto>>>> GetActive();
    }
}
