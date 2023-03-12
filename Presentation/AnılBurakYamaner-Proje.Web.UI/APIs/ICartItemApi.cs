using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ICartItemApi
    {
        [Get("/cartItem")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> List();

        [Get("/cartItem/{Id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Get(Guid Id);

        [Post("/cartItem")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Post(CartItemRequestDto request);

        [Put("/cartItem/{Id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Put(Guid Id, CartItemRequestDto request);

        [Delete("/cartItem/{Id}")]
        Task<ApiResponse<WebApiResponse<CartItemResponseDto>>> Delete(Guid Id);

        [Get("/cartItem/activate/{Id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid Id);


        [Get("/cartItem/query/{cartId}")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> GetCartItemQuery(Guid cartId);

        [Get("/cartItem/getactive")]
        Task<ApiResponse<WebApiResponse<List<CartItemResponseDto>>>> GetActive();
    }
}
