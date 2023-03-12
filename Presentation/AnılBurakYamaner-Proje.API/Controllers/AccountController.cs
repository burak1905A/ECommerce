using AnılBurakYamaner_Proje.Common.Dtos.Login;
using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Common.Models;
using AnılBurakYamaner_Proje.Service.Repository.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnılBurakYamaner_Proje.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository,
            IConfiguration configuration, 
            IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WebApiResponse<UserResponseDto>> Login([FromQuery] LoginRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.GetByDefault(x => x.Email == request.Email &&
                x.Password == request.Password);
                if (result != null)
                {
                    UserResponseDto rm = _mapper.Map<UserResponseDto>(result);
                    rm.Password = null;
                    rm.AcceessToken = GetAcceessToken(rm, request.Password);
                    return new WebApiResponse<UserResponseDto>(true, "Success", rm);
                }
            }
            return new WebApiResponse<UserResponseDto>(false, ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList().ToString());
        }

        private GetAcceessTokenDto GetAcceessToken(UserResponseDto rm, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,rm.Id.ToString()),
                new Claim("FirstName",rm.FirstName),
                new Claim("LastName",rm.LastName),
                new Claim(JwtRegisteredClaimNames.Email,rm.Email)
            };

            var systemSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            var signingCredential = new SigningCredentials(systemSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Token:Expires"]));
            var ticks = expires.ToUnixTime();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signingCredential
                );

            return new GetAcceessTokenDto
            {
                TokenType = "AnılBurakYamaner_ProjeAccessToken",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expires = ticks,
                RefreshToken = $"{rm.Email}_{password}_{ticks}".Encrypt()
            };
        }
        [HttpGet("refreshtoken")]
        public async Task<WebApiResponse<GetAcceessTokenDto>> RefreshToken([FromQuery] RefreshToken request)
        {
            if (string.IsNullOrEmpty(request.Refresh_Token))
                throw new Exception("Invalid Refresh Token");

            var key = request.Refresh_Token.Decrypt();
            var userInfo = key.Split('_');

            if (userInfo.Length < 3 || userInfo[0] != request.Email)
                throw new Exception("Geçersiz Refresh Token");


            var result = await _userRepository.GetByDefault(x => x.Email == userInfo[0] && x.Password == userInfo[1]);
            if (result != null)
            {
                UserResponseDto rm = _mapper.Map<UserResponseDto>(result);
                rm.Password = null;
                rm.AcceessToken = GetAcceessToken(rm, userInfo[1]);
                return new WebApiResponse<GetAcceessTokenDto>(true, "Success", rm.AcceessToken);
            }
            return new WebApiResponse<GetAcceessTokenDto>(false, "User Not Found");
        }
    }
}
