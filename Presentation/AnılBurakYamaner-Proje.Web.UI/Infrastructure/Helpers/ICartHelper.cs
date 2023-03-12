using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.Category;
using System;
using System.Collections.Generic;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers
{
    public interface ICartHelper
    {
         List<CategoryResponseDto> GetCategories();
        CartResponseDto GetActiveCart(Guid userId);
    }
}