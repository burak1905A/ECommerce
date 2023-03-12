using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        public CartController(ICartApi cartApi, ICartItemApi cartItemApi)
        {
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
        }
        public async Task<IActionResult> Index()
        {
            if (User != null && User.Claims != null && User.Claims.Count() > 0)
            {
                var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var activeCart = await _cartApi.GetCartsByQuery(userId);
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

                return View(new List<CartItemViewModel>());
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductViewModel item )
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            var existingCart = await _cartApi.GetCartsByQuery(userId);
            if (existingCart.IsSuccessStatusCode )
            {
                var existingCartData = existingCart.Content.ResultData;
                if(existingCartData == null||existingCartData.Count==0) {
                    CartRequestDto cart = new CartRequestDto { UserId = userId, SessionId = "0" };
                    var cartRequest = await _cartApi.Post(cart);
                    if (cartRequest.IsSuccessStatusCode && cartRequest.Content.IsSuccess)
                    {
                        var cartResponseDto = cartRequest.Content.ResultData;

                        CartItemRequestDto cartItem = new CartItemRequestDto { CartId = cartResponseDto.Id, ProductId = item.Id, Quantity = 1 };
                        var cartItemRequest = await _cartItemApi.Post(cartItem);
                    }
                }
                else
                {

                    CartItemRequestDto cartItem = new CartItemRequestDto { CartId = existingCartData.FirstOrDefault().Id, ProductId = item.Id, Quantity = 1 };
                    var cartItemRequest = await _cartItemApi.Post(cartItem);
                }

            }
                return RedirectToAction("Index", "Cart");
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




