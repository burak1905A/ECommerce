using AnılBurakYamaner_Proje.Common.Dtos.User;
using AnılBurakYamaner_Proje.Common.WorkContext;
using AnılBurakYamaner_Proje.Service.Repository.User;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Helper
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ApiWorkContext(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserResponseDto CurrentUser
        {
            get
            {
                //using Microsoft.AspNetCore.Authentication.JwtBearer
                var authResult = _httpContextAccessor.HttpContext.AuthenticateAsync (JwtBearerDefaults.AuthenticationScheme).Result;
                if (!authResult.Succeeded)
                    return null;

                var email = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value;
                var firstName = authResult.Principal.Claims.FirstOrDefault(x => x.Type == "FirstName").Value;
                var lastName = authResult.Principal.Claims.FirstOrDefault(x => x.Type == "LastName").Value;
                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                return new UserResponseDto
                {
                    Id = Guid.Parse(userId),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };
            }
            set
            {
                CurrentUser = value;
            }
        }
    }
}
