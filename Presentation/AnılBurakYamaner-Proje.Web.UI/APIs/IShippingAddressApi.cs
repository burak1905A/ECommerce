using AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IShippingAddressApi
    {
        [Get("/shippingAddress")]
        Task<ApiResponse<WebApiResponse<List<ShippingAddressResponseDto>>>> List();

        [Get("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponseDto>>> Get(Guid id);

        [Post("/shippingAddress")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponseDto>>> Post(ShippingAddressRequestDto request);

        [Put("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponseDto>>> Put(Guid id, ShippingAddressRequestDto request);

        [Delete("/shippingAddress/{id}")]
        Task<ApiResponse<WebApiResponse<ShippingAddressResponseDto>>> Delete(Guid id);

        [Get("/shippingAddress/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/shippingAddress/getactive")]
        Task<ApiResponse<WebApiResponse<List<ShippingAddressResponseDto>>>> GetActive();
    }
}
