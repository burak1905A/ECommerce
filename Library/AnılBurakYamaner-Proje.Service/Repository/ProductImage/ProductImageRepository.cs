using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.ProductImage
{
    public class ProductImageRepository : Repository<EF.ProductImage>, IProductImageRepository
    {
        private readonly DataContext _context;
        public ProductImageRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}