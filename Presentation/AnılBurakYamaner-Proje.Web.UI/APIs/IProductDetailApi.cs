using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Dtos.ProductDetail;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductDetailApi
    {
        [Get("/productDetail")]
        Task<ApiResponse<WebApiResponse<List<ProductDetailResponseDto>>>> List();

        [Get("/productDetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponseDto>>> Get(Guid id);

        [Post("/productDetail")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponseDto>>> Post(ProductDetailRequestDto request);

        [Put("/productDetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponseDto>>> Put(Guid id, ProductDetailRequestDto request);

        [Delete("/productDetail/{id}")]
        Task<ApiResponse<WebApiResponse<ProductDetailResponseDto>>> Delete(Guid id);

        [Get("/productDetail/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productDetail/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductDetailResponseDto>>>> GetActive();


        [Get("/product/GetByProductId/{id}")]
        Task<ApiResponse<WebApiResponse<List<ProductDetailResponseDto>>>> GetByProductId(Guid id);
    }
}
