using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using AnılBurakYamaner_Proje.Service.Repository.OrderDetail;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.OrderAddress
{
    public class OrderDetailRepository : Repository<EF.OrderDetail>, IOrderDetailRepository
    {
        private readonly DataContext _context;
        public OrderDetailRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}