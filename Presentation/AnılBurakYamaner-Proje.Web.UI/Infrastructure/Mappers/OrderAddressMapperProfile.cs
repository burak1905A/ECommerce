using AnılBurakYamaner_Proje.Common.Dtos.OrderAddress;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Models.OrderAddressViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Mappers
{
    public class OrderAddressMapperProfile : Profile
    {
        public OrderAddressMapperProfile()
        {
            CreateMap<OrderAddressViewModel, OrderAddressRequestDto>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderAddressViewModel, OrderAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderAddressViewModel, OrderAddressRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderAddressViewModel, OrderAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderAddressViewModel, OrderAddressRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderAddressViewModel, OrderAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
