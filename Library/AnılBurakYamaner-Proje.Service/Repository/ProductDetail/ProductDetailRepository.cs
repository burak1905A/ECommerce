using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.ProductDetail
{
    public class ProductDetailRepository : Repository<EF.ProductDetail>, IProductDetailRepository
    {
        private readonly DataContext _context;
        public ProductDetailRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}