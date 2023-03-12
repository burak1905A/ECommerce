using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Town
{
    public class TownRepository : Repository<EF.Town>, ITownRepository
    {
        private readonly DataContext _context;
        public TownRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}