using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.UserViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ProductController : Controller
    {
        private readonly IUserProductApi _productApi;
        private readonly IMapper _mapper;
        private readonly IUserApi _userApi;
        public ProductController(
         IMapper mapper,
         IUserProductApi productApi,
            IUserApi userApi
         )
        {
            _userApi = userApi;
            _mapper = mapper;
            _productApi = productApi;
          
        }
        public async Task<IActionResult> Index(Guid id)
        {
            var getPostResult = await _productApi.ProductDetail(id);
            if (getPostResult.IsSuccessStatusCode && getPostResult.Content.IsSuccess && getPostResult.Content.ResultData != null)
            {
                ProductViewModel updateProduct = _mapper.Map<ProductViewModel>(getPostResult.Content.ResultData);
                var getUserResult = await _userApi.Get(updateProduct.UserId);
                if (getUserResult.IsSuccessStatusCode && getUserResult.Content.IsSuccess && getUserResult.Content.ResultData != null)
                {
                    UserViewModel userViewModel = _mapper.Map<UserViewModel>(getUserResult.Content.ResultData);
                    return View(Tuple.Create(updateProduct, userViewModel));
                }
            }
            return View();

        }
    }
}
