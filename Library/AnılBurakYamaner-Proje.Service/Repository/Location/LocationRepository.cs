using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Location
{
    public class LocationRepository : Repository<EF.Location>, ILocationRepository
    {
        private readonly DataContext _context;
        public LocationRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}