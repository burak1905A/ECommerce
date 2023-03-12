using AnılBurakYamaner_Proje.API.Infrastructor.Helper;
using AnılBurakYamaner_Proje.Common.WorkContext;
using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Brand;
using AnılBurakYamaner_Proje.Service.Repository.Cart;
using AnılBurakYamaner_Proje.Service.Repository.CartItem;
using AnılBurakYamaner_Proje.Service.Repository.Category;
using AnılBurakYamaner_Proje.Service.Repository.Country;
using AnılBurakYamaner_Proje.Service.Repository.Currency;
using AnılBurakYamaner_Proje.Service.Repository.CurrentAccount;
using AnılBurakYamaner_Proje.Service.Repository.Location;
using AnılBurakYamaner_Proje.Service.Repository.Maillist;
using AnılBurakYamaner_Proje.Service.Repository.Member;
using AnılBurakYamaner_Proje.Service.Repository.Order;
using AnılBurakYamaner_Proje.Service.Repository.OrderAddress;
using AnılBurakYamaner_Proje.Service.Repository.OrderDetail;
using AnılBurakYamaner_Proje.Service.Repository.OrderItem;
using AnılBurakYamaner_Proje.Service.Repository.Product;
using AnılBurakYamaner_Proje.Service.Repository.ProductComment;
using AnılBurakYamaner_Proje.Service.Repository.ProductDetail;
using AnılBurakYamaner_Proje.Service.Repository.ProductImage;
using AnılBurakYamaner_Proje.Service.Repository.ProductPrice;
using AnılBurakYamaner_Proje.Service.Repository.ShippingAddress;
using AnılBurakYamaner_Proje.Service.Repository.Town;
using AnılBurakYamaner_Proje.Service.Repository.User;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            //API modülünü sürecimize ekliyoruz...
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:Conn"]);
            });

            //.Net Core yapısı tamamiyle dependency Injection yapısıyla çalıştığından Interface ile Service ve
            //Repository classlarının bağımlılığını tanımlıyoruz.

            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddHttpContextAccessor();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();
            services.AddTransient<IBrandRepository,BrandRepository>();
            services.AddTransient<ICartRepository,CartRepository>();
            services.AddTransient<ICartItemRepository,CartItemRepository>();
            services.AddTransient<ICountryRepository,CountryRepository>();
            services.AddTransient<ICurrencyRepository,CurrencyRepository>();
            services.AddTransient<CurrentAccountRepository, CurrentAccountRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMaillistRepository,MaillistRepository>();
            services.AddTransient<IMemberRepository,MemberRepository>();
            services.AddTransient<IOrderRepository,OrderRepository>();
            services.AddTransient<IOrderAddressRepository,OrderAddressRepository>();
            services.AddTransient<IOrderDetailRepository,OrderDetailRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
            services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IProductPriceRepository, ProductPriceRepository>();
            services.AddTransient<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddTransient<ITownRepository, TownRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IUserRepository,UserRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //JWT Auth
            //use multiple authentication https://code-maze.com/dotnet-multiple-authentication-schemes/
            //[Authorize(Policy = "AdminJwtScheme")]
            //[Authorize(Policy = "UserJwtScheme")]
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //using Microsoft.IdentityModel.Tokens
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]))
                    };
                });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                //Microsoft.OpenApi.Models.
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0",
                    Description = "AnılBurakYamaner_ProjeBackend Servis Projesi(ASP.NET Core 3.1)",
                    TermsOfService = new Uri("http://swagger.io.terms")
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "AnılBurakYamaner_Proje Core API Projesi JWT Authorization header (Bearer) kullanmaktadır. Örnek: \"Authorization: Baarer {token}\"",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MY API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
