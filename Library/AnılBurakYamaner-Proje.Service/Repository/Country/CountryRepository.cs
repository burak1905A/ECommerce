using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Country
{
    public class CountryRepository : Repository<EF.Country>, ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}