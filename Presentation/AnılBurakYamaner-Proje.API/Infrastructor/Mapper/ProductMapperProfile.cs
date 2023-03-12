using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Model.Entities;
using AutoMapper;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Mapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
