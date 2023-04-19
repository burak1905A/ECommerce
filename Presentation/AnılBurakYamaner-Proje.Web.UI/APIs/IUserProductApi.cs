using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IUserProductApi
    {
        [Get("/product")]
        Task<ApiResponse<WebApiResponse<List<ProductResponseDto>>>> List();

        [Get("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponseDto>>> Get(Guid id);

        [Get("/product/Slug/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponseDto>>> ProductDetail(Guid id);

        [Post("/product")]
        Task<ApiResponse<WebApiResponse<ProductResponseDto>>> Post(ProductRequestDto request);

        [Put("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponseDto>>> Put(Guid id, ProductRequestDto request);

        [Delete("/product/{id}")]
        Task<ApiResponse<WebApiResponse<ProductResponseDto>>> Delete(Guid id);

        [Get("/product/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/product/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductResponseDto>>>> GetActive();

        [Get("/product/GetByCategoryId/{id}")]
        Task<ApiResponse<WebApiResponse<List<ProductResponseDto>>>> GetByCategoryId(Guid id);


        [Get("/product/GetByBrandId/{id}")]
        Task<ApiResponse<WebApiResponse<List<ProductResponseDto>>>> GetByBrandId(Guid id);
    }
}
