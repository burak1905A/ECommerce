using AnılBurakYamaner_Proje.Common.Dtos.Cart;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Areas.User.Models.CartViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Mappers
{
    public class CartMapperProfile : Profile
    {
        public CartMapperProfile()
        {
            CreateMap<CartViewModel, CartRequestDto>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CartViewModel, CartResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCartViewModel, CartRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCartViewModel, CartResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCartViewModel, CartRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCartViewModel, CartResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
