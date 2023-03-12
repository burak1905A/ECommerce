using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.İmageFile).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ShowcaseContent).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.CanonicalUrl).HasMaxLength(255).IsRequired(false);

                entity
                    .HasOne(c => c.CreatedUserCategory)
                    .WithMany(u => u.CreatedUserCategories)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCategory)
                    .WithMany(u => u.ModifiedUserCategories)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
