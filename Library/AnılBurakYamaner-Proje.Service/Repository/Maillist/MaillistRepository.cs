using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Maillist
{
    public class MaillistRepository : Repository<EF.Maillist>, IMaillistRepository
    {
        private readonly DataContext _context;
        public MaillistRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}