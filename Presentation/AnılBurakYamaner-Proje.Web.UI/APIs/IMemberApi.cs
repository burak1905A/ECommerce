using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface IMemberApi
    {
        [Get("/member")]
        Task<ApiResponse<WebApiResponse<List<MemberResponseDto>>>> List();

        [Get("/member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponseDto>>> Get(Guid id);

        [Post("/member")]
        Task<ApiResponse<WebApiResponse<MemberResponseDto>>> Post(MemberRequestDto request);

        [Put("/member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponseDto>>> Put(Guid id, MemberRequestDto request);

        [Delete("/member/{id}")]
        Task<ApiResponse<WebApiResponse<MemberResponseDto>>> Delete(Guid id);

        [Get("/member/activate/{id}")]
        Task<ApiResponse<WebApiResponse<bool>>> Activate(Guid id);

        [Get("/member/getactive")]
        Task<ApiResponse<WebApiResponse<List<MemberResponseDto>>>> GetActive();
    }
}
