using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers
{
    public interface ICartHelper
    {
        List<CategoryResponseDto> GetCategories();
        CartResponseDto GetActiveCart(IHttpContextAccessor _httpContextAccessor, ClaimsPrincipal User);
    }
}