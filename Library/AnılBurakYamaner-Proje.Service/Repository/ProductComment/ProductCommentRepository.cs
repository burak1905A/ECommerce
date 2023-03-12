using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.ProductComment
{
    public class ProductCommentRepository : Repository<EF.ProductComment>, IProductCommentRepository
    {
        private readonly DataContext _context;
        public ProductCommentRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}