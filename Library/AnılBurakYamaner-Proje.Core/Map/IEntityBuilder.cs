using Microsoft.EntityFrameworkCore;

namespace AnılBurakYamaner_Proje.Core.Map
{
    public interface IEntityBuilder
    {
        void Build(ModelBuilder builder);
    }
}
