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


namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;
     
        private readonly IAdminUserApi _userApi;

        public AccountController(IAccountApi accountApi, IMapper mapper, IAdminUserApi userApi)
        {
            _accountApi = accountApi;
            _mapper = mapper;
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
                var requestDto = _mapper.Map<LoginRequestDto>(request);
                requestDto.LoginType = "Admin";

                var loginRequest = await _accountApi.Login(requestDto);
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

                    HttpContext.Response.Cookies.Append("AnılBurakYamaner-AdminProjeAccessToken", JsonConvert.SerializeObject(cookieModel).Encrypt());
                    await HttpContext.SignInAsync(principal);

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
            HttpContext.Response.Cookies.Delete("AnılBurakYamaner-AdminProjeAccessToken");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}