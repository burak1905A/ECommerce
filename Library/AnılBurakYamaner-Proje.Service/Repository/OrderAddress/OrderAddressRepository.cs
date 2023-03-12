using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.OrderAddress
{
    public class OrderAddressRepository : Repository<EF.OrderAddress>, IOrderAddressRepository
    {
        private readonly DataContext _context;
        public OrderAddressRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}