using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderItemApi
    {
        [Get("/orderItem")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> List();

        [Get("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Get(Guid id);

        [Post("/orderItem")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Post(OrderItemRequestDto request);

        [Put("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Put(Guid id, OrderItemRequestDto request);

        [Delete("/orderItem/{id}")]
        Task<ApiResponse<WebApiResponse<OrderItemResponseDto>>> Delete(Guid id);

        [Get("/orderItem/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderItem/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> GetActive();


        [Get("/post/GetByOrderId/{id}")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> GetByOrderId(Guid id);

        [Get("/post/GetByProductId/{id}")]
        Task<ApiResponse<WebApiResponse<List<OrderItemResponseDto>>>> GetByProductId(Guid id);
    }
}
