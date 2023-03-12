using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Cart
{
    public class CartRepository : Repository<EF.Cart>, ICartRepository
    {
        private readonly DataContext _context;
        public CartRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}