using AnılBurakYamaner_Proje.Common.Dtos.Member;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Model.Entities;
using AutoMapper;

namespace AnılBurakYamaner_Proje.API.Infrastructor.Mapper
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<Member, MemberRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Member, MemberResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
