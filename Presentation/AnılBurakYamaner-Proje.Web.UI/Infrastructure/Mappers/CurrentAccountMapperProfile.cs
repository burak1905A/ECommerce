using AnılBurakYamaner_Proje.Common.Dtos.CurrentAccount;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Models.CurrentAccountViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Mappers
{
    public class CurrentAccountMapperProfile : Profile
    {
        public CurrentAccountMapperProfile()
        {
            CreateMap<CurrentAccountViewModel, CurrentAccountRequestDto>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CurrentAccountViewModel, CurrentAccountResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrentAccountViewModel, CurrentAccountRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateCurrentAccountViewModel, CurrentAccountResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrentAccountViewModel, CurrentAccountRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCurrentAccountViewModel, CurrentAccountResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
