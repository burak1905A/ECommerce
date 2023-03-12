using AnılBurakYamaner_Proje.Common.Dtos.Brand;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Model.Entities;
using AutoMapper;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Mapper
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<Brand, BrandRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Brand, BrandResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
