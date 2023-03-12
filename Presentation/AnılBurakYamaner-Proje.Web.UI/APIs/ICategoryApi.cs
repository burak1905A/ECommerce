using AnılBurakYamaner_Proje.Common.Dtos.Category;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICategoryApi
    {
        [Get("/category")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponseDto>>>> List();

        [Get("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponseDto>>> Get(Guid id);

        [Post("/category")]
        Task<ApiResponse<WebApiResponse<CategoryResponseDto>>> Post(CategoryRequestDto request);

        [Put("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponseDto>>> Put(Guid id, CategoryRequestDto request);

        [Delete("/category/{id}")]
        Task<ApiResponse<WebApiResponse<CategoryResponseDto>>> Delete(Guid id);

        [Get("/category/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/category/getactive")]
        Task<ApiResponse<WebApiResponse<List<CategoryResponseDto>>>> GetActive();
    }
}
