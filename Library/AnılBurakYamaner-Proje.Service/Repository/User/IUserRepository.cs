using AnılBurakYamaner_Proje.Core.Repository;
using EF = AnılBurakYamaner_Proje.Model.Entities;

namespace AnılBurakYamaner_Proje.Service.Repository.User
{
    public interface IUserRepository : IRepository<EF.User>
    {
    }
}

