using AnılBurakYamaner_Proje.Common.Dtos.Order;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderApi
    {
        [Get("/order")]
        Task<ApiResponse<WebApiResponse<List<OrderResponseDto>>>> List();

        [Get("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponseDto>>> Get(Guid id);

        [Post("/order")]
        Task<ApiResponse<WebApiResponse<OrderResponseDto>>> Post(OrderRequestDto request);

        [Put("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponseDto>>> Put(Guid id, OrderRequestDto request);

        [Delete("/order/{id}")]
        Task<ApiResponse<WebApiResponse<OrderResponseDto>>> Delete(Guid id);

        [Get("/order/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/order/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderResponseDto>>>> GetActive();
    }
}
