using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartItemViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Controllers
{
    [Area("User")]
    public class CartController : Controller
    {

        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(ICartApi cartApi, ICartItemApi cartItemApi, IHttpContextAccessor httpContextAccessor)
        {
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var cartResponse = new CartViewModel();
            ApiResponse<WebApiResponse<List<CartResponseDto>>> activeCart = new ApiResponse<WebApiResponse<List<CartResponseDto>>>(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound), null, null) { };
            if (User != null && User.Claims != null && User.Claims.Count() > 0)
            {
                var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                activeCart = _cartApi.GetCartsByQuery(userId).Result;
            }
            else
            {

                if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("AnılBurakYamaner-ProjeCart"))
                {
                    var cookieStr = _httpContextAccessor.HttpContext.Request.Cookies["AnılBurakYamaner-ProjeCart"].Decrypt();
                    var sessionId = JsonConvert.DeserializeObject<Guid>(cookieStr);
                    activeCart = _cartApi.GetCartsBySession(sessionId).Result;

                }

            }
            if (activeCart.IsSuccessStatusCode && activeCart.Content.IsSuccess)
            {
                var cart = activeCart.Content.ResultData;
                var cartItemsResult = await _cartItemApi.GetCartItemQuery(cart.FirstOrDefault().Id);
                if (cartItemsResult.IsSuccessStatusCode && cartItemsResult.Content.IsSuccess)
                {
                    var cartItems = cartItemsResult.Content.ResultData.Select(x => new CartItemViewModel
                    {
                        Id = x.Id,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Product = new ProductViewModel
                        {
                            Name = x.Product.Name,
                            Barcode = x.Product.Barcode,
                            FullName = x.Product.FullName,
                            Price1 = x.Product.Price1,
                            Slug = x.Product.Slug,
                        }
                    }).ToList();
                    return View(new CartViewModel
                    {
                        CartItems = cartItems,
                        Id = cart.FirstOrDefault().Id,
                    });

                }
            }

            return View(cartResponse);

            return View(new CartViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProductViewModel item)
        {
            Guid? userId = null;
            Guid? sessionId = null;
            ApiResponse<WebApiResponse<List<CartResponseDto>>> existingCart = new ApiResponse<WebApiResponse<List<CartResponseDto>>>(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK), null, null);
            if (User != null && User.Claims != null && User.Claims.Count() > 0)
            {
                userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                existingCart = await _cartApi.GetCartsByQuery(userId.Value);
            }
            else
            {

                if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("AnılBurakYamaner-ProjeCart"))
                {
                    var cookieStr = _httpContextAccessor.HttpContext.Request.Cookies["AnılBurakYamaner-ProjeCart"].Decrypt();
                    sessionId = JsonConvert.DeserializeObject<Guid?>(cookieStr);
                    existingCart = await _cartApi.GetCartsBySession(sessionId.Value);

                }
                else
                {
                    sessionId = Guid.NewGuid();
                    HttpContext.Response.Cookies.Append("AnılBurakYamaner-ProjeCart", JsonConvert.SerializeObject(sessionId).Encrypt());
                }
            }
            if (existingCart.IsSuccessStatusCode)
            {
                var existingCartData = existingCart.Content?.ResultData;
                if (existingCartData == null || existingCartData.Count == 0)
                {
                    CartRequestDto cart = new CartRequestDto { UserId = userId, SessionId = sessionId };
                    var cartRequest = await _cartApi.Post(cart);
                    if (cartRequest.IsSuccessStatusCode && cartRequest.Content.IsSuccess)
                    {
                        var cartResponseDto = cartRequest.Content.ResultData;

                        CartItemRequestDto cartItem = new CartItemRequestDto { CartId = cartResponseDto.Id, ProductId = item.Id, Quantity = item.Quantity };
                        var cartItemRequest = await _cartItemApi.Post(cartItem);
                    }
                }
                else
                {

                    CartItemRequestDto cartItem = new CartItemRequestDto { CartId = existingCartData.FirstOrDefault().Id, ProductId = item.Id, Quantity = item.Quantity };
                    var cartItemRequest = await _cartItemApi.Post(cartItem);
                }


            }



            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _cartItemApi.Delete(Id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess)
            {
                var cartResponseDto = result.Content.ResultData;
            }
            return RedirectToAction("Index", "Cart");
        }
    }

}




