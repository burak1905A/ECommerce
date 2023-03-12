using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Dtos.ProductImage;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductImageApi
    {
        [Get("/productImage")]
        Task<ApiResponse<WebApiResponse<List<ProductImageResponseDto>>>> List();

        [Get("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponseDto>>> Get(Guid id);

        [Post("/productImage")]
        Task<ApiResponse<WebApiResponse<ProductImageResponseDto>>> Post(ProductImageRequestDto request);

        [Put("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponseDto>>> Put(Guid id, ProductImageRequestDto request);

        [Delete("/productImage/{id}")]
        Task<ApiResponse<WebApiResponse<ProductImageResponseDto>>> Delete(Guid id);

        [Get("/productImage/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productImage/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductImageResponseDto>>>> GetActive();

        [Get("/product/GetByProductId/{id}")]
        Task<ApiResponse<WebApiResponse<List<ProductImageResponseDto>>>> GetByProductId(Guid id);
    }
}
