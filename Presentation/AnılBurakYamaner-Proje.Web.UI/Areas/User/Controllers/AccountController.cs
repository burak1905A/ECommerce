using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Dtos.CartItem;
using AnılBurakYamaner_Proje.Common.Dtos.Login;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.AccountViewModels;
using AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AnılBurakYamaner_Proje.Web.UI.Areas.User.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;
        private readonly ICartApi _cartApi;
        private readonly ICartItemApi _cartItemApi;
        private readonly IUserApi _userApi;

        public AccountController(IAccountApi accountApi, IMapper mapper, ICartApi cartApi, ICartItemApi cartItemApi, IUserApi userApi)
        {
            _accountApi = accountApi;
            _mapper = mapper;
            _cartApi = cartApi;
            _cartItemApi = cartItemApi;
            _userApi = userApi;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = await _accountApi.Login(_mapper.Map<LoginRequestDto>(request));
                if (loginRequest.IsSuccessStatusCode && loginRequest.Content.IsSuccess)
                {
                    UserResponseDto user = loginRequest.Content.ResultData;
                    var claims = new List<Claim>()
                    {
                        new Claim("Id",user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Surname,user.LastName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim("Image",user.ImageUrl),
                        new Claim("IsAdmin",user.IsAdmin.ToString())
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    var cookieModel = new CookieModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        ImagePath = user.ImageUrl,
                        AcceessToken = user.AcceessToken
                    };

                    HttpContext.Response.Cookies.Append("AnılBurakYamaner-ProjeAccessToken", JsonConvert.SerializeObject(cookieModel).Encrypt());
                    await HttpContext.SignInAsync(principal);

                    if (HttpContext.Request.Cookies.ContainsKey("AnılBurakYamaner-ProjeCart"))
                    {
                        var cookieStr = HttpContext.Request.Cookies["AnılBurakYamaner-ProjeCart"].Decrypt();
                        var sessionId = JsonConvert.DeserializeObject<Guid>(cookieStr);

                        var activeCartSession = await _cartApi.GetCartsBySession(sessionId);
                        var activeCartUser = await _cartApi.GetCartsByQuery(user.Id);

                        if (activeCartSession != null && activeCartSession.IsSuccessStatusCode)
                        {
                            var cart = activeCartSession.Content.ResultData;
                            if (cart != null && cart.Count > 0)
                            {
                                var existingCart = cart.FirstOrDefault();
                                if (activeCartUser != null && activeCartUser.IsSuccessStatusCode)
                                {
                                    var cartUser = activeCartUser.Content.ResultData;
                                    if (cartUser != null && cartUser.Count > 0)
                                    {
                                        var existingCartUser = cartUser.FirstOrDefault();
                                        foreach (var item in existingCart.CartItems)
                                        {

                                            CartItemRequestDto cartItem = new CartItemRequestDto { CartId = existingCartUser.Id, ProductId = item.ProductId, Quantity = item.Quantity };
                                            var cartItemRequest = await _cartItemApi.Post(cartItem);
                                        }
                                        var response = await _cartApi.Put(existingCart.Id, new CartRequestDto
                                        {
                                            Id = existingCart.Id,
                                            Locked = true,
                                            SessionId = sessionId,
                                            Status = existingCart.Status,
                                            UserId = user.Id
                                        });
                                    }
                                    else
                                    {
                                        var response = await _cartApi.Put(existingCart.Id, new CartRequestDto
                                        {
                                            Id = existingCart.Id,
                                            Locked = existingCart.Locked,
                                            SessionId = sessionId,
                                            Status = existingCart.Status,
                                            UserId = user.Id
                                        });
                                    }
                                }
                                else
                                {
                                    var response = await _cartApi.Put(existingCart.Id, new CartRequestDto
                                    {
                                        Id = existingCart.Id,
                                        Locked = existingCart.Locked,
                                        SessionId = sessionId,
                                        Status = existingCart.Status,
                                        UserId = user.Id
                                    });
                                }


                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("hata", "Kullanıcı Bulunamadı.Lütfen Üye Olunuz...!");
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            if (ModelState.IsValid)
            {
                var existuser = await _userApi.ExistsUser(request.Email);
                if (existuser.IsSuccessStatusCode &&
                    existuser.Content.IsSuccess &&
                    existuser?.Content?.ResultData != null && existuser.Content.ResultData)
                {
                    ModelState.AddModelError("hata", "Email Kullanılıyor...");
                    return View();

                }
                UserRequestDto item = new UserRequestDto
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.SurName,
                    Password = request.Password,
                };
                var insertResult = await _userApi.Post(item);
                if (insertResult.IsSuccessStatusCode &&
                    insertResult.Content.IsSuccess &&
                    insertResult?.Content?.ResultData != null)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("hata", "İşlem Tamamlanamadı...");


                return View();
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("AnılBurakYamaner-ProjeAccessToken");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}