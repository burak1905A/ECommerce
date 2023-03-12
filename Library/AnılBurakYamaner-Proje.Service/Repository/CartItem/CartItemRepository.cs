using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.CartItem
{
    public class CartItemRepository : Repository<EF.CartItem>, ICartItemRepository
    {
        private readonly DataContext _context;
        public CartItemRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}