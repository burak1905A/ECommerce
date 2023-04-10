using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    //[Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartApi
    {
        [Get("/cart")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> List();

        [Get("/cart/{Id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Get(Guid Id);

        [Get("/cart/query/{userId}")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetCartsByQuery(Guid userId);

        [Post("/cart")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Post(CartRequestDto request);

        [Put("/cart/{Id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Put(Guid Id, CartRequestDto request);

        [Delete("/cart/{Id}")]
        Task<ApiResponse<WebApiResponse<CartResponseDto>>> Delete(Guid Id);

        [Get("/cart/activate/{Id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid Id);

        [Get("/cart/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetActive();

        [Get("/cart/query/session/{sessionId}")]
        Task<ApiResponse<WebApiResponse<List<CartResponseDto>>>> GetCartsBySession(Guid? sessionId);
    }
}
