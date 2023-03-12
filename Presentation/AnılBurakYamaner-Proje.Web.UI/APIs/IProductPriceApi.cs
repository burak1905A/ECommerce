using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Dtos.ProductPrice;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductPriceApi
    {
        [Get("/productPrice")]
        Task<ApiResponse<WebApiResponse<List<ProductPriceResponseDto>>>> List();

        [Get("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Get(Guid id);

        [Post("/productPrice")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Post(ProductPriceRequestDto request);

        [Put("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Put(Guid id, ProductPriceRequestDto request);

        [Delete("/productPrice/{id}")]
        Task<ApiResponse<WebApiResponse<ProductPriceResponseDto>>> Delete(Guid id);

        [Get("/productPrice/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productPrice/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductPriceResponseDto>>>> GetActive();

        [Get("/product/GetByProductId/{id}")]
        Task<ApiResponse<WebApiResponse<List<ProductResponseDto>>>> GetByProductId(Guid id);
    }
}
