using AnılBurakYamaner_Proje.Model.Context;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace AnılBurakYamaner_Proje.Model.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../AnılBurakYamaner-Proje.API")
            };
            return resolver.ServiceProvider.GetService(typeof(DataContext)) as DataContext;
        }
    }
}
