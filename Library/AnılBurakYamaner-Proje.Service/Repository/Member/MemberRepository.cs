using AnılBurakYamaner_Proje.Model.Context;
using AnılBurakYamaner_Proje.Service.Repository.Base;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.Member
{
    public class MemberRepository : Repository<EF.Member>, IMemberRepository
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context) : base(context)
        {
            _context = context;

        }
    }
}