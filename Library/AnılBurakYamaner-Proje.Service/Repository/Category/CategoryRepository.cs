using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Category
{
    public class CategoryRepository : Repository<EF.Category>, ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context) 
        {
            _context = context;
            //_context.Set<EF.Post>().Add(new EF.Post());
            //this.Add
            //this.Update
            //this.Table
            //this.TableNoTracking
        }
    }
}
