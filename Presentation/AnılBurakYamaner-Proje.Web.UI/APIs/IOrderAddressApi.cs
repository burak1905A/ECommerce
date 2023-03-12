using AnılBurakYamaner_Proje.Common.Dtos.OrderAddress;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IOrderAddressApi
    {
        [Get("/orderAddress")]
        Task<ApiResponse<WebApiResponse<List<OrderAddressResponseDto>>>> List();

        [Get("/orderAddress/{id}")]
        Task<ApiResponse<WebApiResponse<OrderAddressResponseDto>>> Get(Guid id);

        [Post("/orderAddress")]
        Task<ApiResponse<WebApiResponse<OrderAddressResponseDto>>> Post(OrderAddressRequestDto request);

        [Put("/orderAddress/{id}")]
        Task<ApiResponse<WebApiResponse<OrderAddressResponseDto>>> Put(Guid id, OrderAddressRequestDto request);

        [Delete("/orderAddress/{id}")]
        Task<ApiResponse<WebApiResponse<OrderAddressResponseDto>>> Delete(Guid id);

        [Get("/orderAddress/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/orderAddress/getactive")]
        Task<ApiResponse<WebApiResponse<List<OrderAddressResponseDto>>>> GetActive();
    }
}
