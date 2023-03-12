using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.OrderItem
{
    public class OrderItemRepository : Repository<EF.OrderItem>, IOrderItemRepository
    {
        private readonly DataContext _context;
        public OrderItemRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}
