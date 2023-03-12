using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.CurrentAccount
{
    public class CurrentAccountRepository : Repository<EF.CurrentAccount>, ICurrentAccountRepository
    {
        private readonly DataContext _context;
        public CurrentAccountRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}