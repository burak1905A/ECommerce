using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Currency
{
    public class CurrencyRepository : Repository<EF.Currency>, ICurrencyRepository
    {
        private readonly DataContext _context;
        public CurrencyRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}