using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.Order;
using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ShippingAddressViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrderApi _orderApi;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IShippingAddressApi _shippingAddressApi;
        private readonly IMapper _mapper;

        public CheckOutController(IOrderApi orderApi, ICartApi cartApi, ICartItemApi cartItemApi,
            IShippingAddressApi shippingAddressApi, IMapper mapper)
        {
            _orderApi = orderApi;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _shippingAddressApi = shippingAddressApi;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            var existingCart = await _cartApi.GetCartsByQuery(userId);
            var cartItems = new List<CartItemViewModel>();

            if (existingCart.IsSuccessStatusCode && existingCart.Content.IsSuccess)
            {
                var cart = existingCart.Content.ResultData.FirstOrDefault();
                var cartItemResult = await _cartItemApi.GetCartItemQuery(cart.Id);
                if (cartItemResult.IsSuccessStatusCode && cartItemResult.Content.IsSuccess)
                {
                     cartItems = cartItemResult.Content.ResultData.Select(x => new CartItemViewModel
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
                        }
                    }).ToList();
                }
            }
            CheckOutViewModel model = new CheckOutViewModel
            {

                CartItems = cartItems
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CheckOutViewModel model)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            var existingCart = await _cartApi.GetCartsByQuery(userId);
            if (existingCart.IsSuccessStatusCode && existingCart.Content.IsSuccess)
            {
                var cart = existingCart.Content.ResultData.FirstOrDefault();
                var cartItemResult = await _cartItemApi.GetCartItemQuery(cart.Id);
                if (cartItemResult.IsSuccessStatusCode && cartItemResult.Content.IsSuccess)
                {
                    var cartItems = cartItemResult.Content.ResultData.Select(x => new CartItemViewModel
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
                        }
                    }).ToList();

                    ShippingAddressRequestDto shipRequest = new ShippingAddressRequestDto
                    {
                        Address = model.Address,
                        Country = model.Country,
                        FirstName = model.FirstName,
                        SurName = model.SurName,
                        Location = model.Location,
                        SubLocation = model.SubLocation,
                    };
                    var shippAddrResult = await _shippingAddressApi.Post(shipRequest);
                    if (shippAddrResult.IsSuccessStatusCode && shippAddrResult.Content.IsSuccess)
                    {
                        var newshippAddrResult = shippAddrResult.Content.ResultData;

                        var orderItems = new List<OrderItemRequestDto>();
                        foreach(var item in cartItems)
                        {
                            orderItems.Add(new OrderItemRequestDto
                            {
                                ProductBarcode = item.Product.Barcode,
                                ProductName = item.Product.Name,
                                ProductPrice = "",
                                ProductSku ="",
                                ProductId = item.ProductId
                            });
                        }
                        OrderRequestDto orderRequest = new OrderRequestDto
                        {
                            Amount = cartItems.Sum(x => x.Product.Price1),
                            Currency = "TL",
                            UserId = userId,
                            ShippingAddressId = newshippAddrResult.Id,
                            OrderItems = orderItems,
                            CustomerFirstname = model.FirstName,
                            CustomerSurname = model.SurName,
                            CustomerEmail = ""
                        };
                        

                        var orderResult = await _orderApi.Post(orderRequest);
                        if (orderResult.IsSuccessStatusCode && orderResult.Content.IsSuccess)
                        {
                            var neworderResult = orderResult.Content.ResultData;
                            cart.Locked = true;
                             CartRequestDto cartRequest = new CartRequestDto
                            {
                                Id = cart.Id,
                                Locked = cart.Locked,
                                SessionId = cart.SessionId,
                                Status = cart.Status, 
                                UserId = cart.UserId 
                            };
                            await _cartApi.Put(cart.Id , cartRequest);
                        }


                        return RedirectToAction("Index","CheckOut");
                    }
                }
                return RedirectToAction("Index", "CheckOut");
            }
            return RedirectToAction("Index", "CheckOut");
        }
        
    }
    
}
