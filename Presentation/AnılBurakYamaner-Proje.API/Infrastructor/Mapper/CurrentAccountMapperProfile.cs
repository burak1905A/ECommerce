
using AnılBurakYamaner_Proje.Common.Dtos.CurrentAccount;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Model.Entities;
using AutoMapper;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Mapper
{
    public class CurrentAccountMapperProfile : Profile
    {
        public CurrentAccountMapperProfile()
        {
            CreateMap<CurrentAccount, CurrentAccountRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CurrentAccount, CurrentAccountResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
