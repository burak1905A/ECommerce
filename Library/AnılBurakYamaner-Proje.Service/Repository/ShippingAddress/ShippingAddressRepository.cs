using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.ShippingAddress
{
    public class ShippingAddressRepository : Repository<EF.ShippingAddress>, IShippingAddressRepository
    {
        private readonly DataContext _context;
        public ShippingAddressRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}