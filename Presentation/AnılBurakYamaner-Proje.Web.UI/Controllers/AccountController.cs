using AnılBurakYamaner_Proje.Common.Dtos.Login;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.APIs;
using AnılBurakYamaner_Proje.Web.UI.Infrastructure.Helpers;
using AnılBurakYamaner_Proje.Web.UI.Models.AccountViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApi _accountApi;
        private readonly IMapper _mapper;

        public AccountController(IAccountApi accountApi, IMapper mapper)
        {
            _accountApi = accountApi;
            _mapper = mapper;
        }
        public IActionResult Login()
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
                    return RedirectToAction("Index", "Home");
                }
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