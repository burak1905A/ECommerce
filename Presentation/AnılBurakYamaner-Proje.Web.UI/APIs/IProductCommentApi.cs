using AnılBurakYamaner_Proje.Common.Dtos.ProductComment;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IProductCommentApi
    {
        [Get("/productComment")]
        Task<ApiResponse<WebApiResponse<List<ProductCommentResponseDto>>>> List();

        [Get("/productComment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponseDto>>> Get(Guid id);

        [Post("/productComment")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponseDto>>> Post(ProductCommentRequestDto request);

        [Put("/productComment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponseDto>>> Put(Guid id, ProductCommentRequestDto request);

        [Delete("/productComment/{id}")]
        Task<ApiResponse<WebApiResponse<ProductCommentResponseDto>>> Delete(Guid id);

        [Get("/productComment/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/productComment/getactive")]
        Task<ApiResponse<WebApiResponse<List<ProductCommentResponseDto>>>> GetActive();
    }
}
