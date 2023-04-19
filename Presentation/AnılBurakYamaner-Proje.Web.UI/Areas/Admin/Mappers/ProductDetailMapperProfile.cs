using AnılBurakYamaner_Proje.Common.Dtos.ProductDetail;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Areas.Admin.Mappers
{
    public class ProductDetailMapperProfile : Profile
    {
        public ProductDetailMapperProfile()
        {
            CreateMap<ProductDetailViewModel, ProductDetailRequestDto>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductDetailViewModel, ProductDetailResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateProductDetailViewModel, ProductDetailRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateProductDetailViewModel, ProductDetailResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductDetailViewModel, ProductDetailRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductDetailViewModel, ProductDetailResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
