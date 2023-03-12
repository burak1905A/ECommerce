using AnılBurakYamaner_Proje.Common.Dtos.Product;
using AnılBurakYamaner_Proje.Common.Dtos.ProductPrice;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Model.Entities;
using AutoMapper;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Mapper
{
    public class ProductPriceMapperProfile : Profile
    {
        public ProductPriceMapperProfile()
        {
            CreateMap<ProductPrice, ProductPriceRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductPrice, ProductPriceResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
