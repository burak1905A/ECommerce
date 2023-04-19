using AnılBurakYamaner_Proje.Common.Dtos.ShippingAddress;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ShippingAddressViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Mappers
{
    public class ShippingAddressMapperProfile : Profile
    {
        public ShippingAddressMapperProfile()
        {
            CreateMap<CheckOutViewModel, ShippingAddressRequestDto>()
           .ReverseMap()
           .IgnoreAllNonExisting()
           .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CheckOutViewModel, ShippingAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateShippingAddressViewModel, ShippingAddressRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateShippingAddressViewModel, ShippingAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateShippingAddressViewModel, ShippingAddressRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateShippingAddressViewModel, ShippingAddressResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
