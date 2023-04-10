using AnılBurakYamaner_Proje.Common.Dtos.OrderItem;
using AnılBurakYamaner_Proje.Common.Extensions;
using AnılBurakYamaner_Proje.Web.UI.Models.OrderItemViewModels;
using AutoMapper;

namespace AnılBurakYamaner_Proje.Web.UI.Infrastructure.Mappers
{
    public class OrderItemMapperProfile : Profile
    {
        public OrderItemMapperProfile()
        {
            CreateMap<OrderItemViewModel, OrderItemRequestDto>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderItemViewModel, OrderItemResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderItemViewModel, OrderItemRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateOrderItemViewModel, OrderItemResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderItemViewModel, OrderItemRequestDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateOrderItemViewModel, OrderItemResponseDto>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
