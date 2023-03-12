using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.ProductPrice
{
    public class ProductPriceRepository : Repository<EF.ProductPrice>, IProductPriceRepository
    {
        private readonly DataContext _context;
        public ProductPriceRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}