using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class BrandMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.DistributorCode).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Distributor).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.İmageFile).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.ShowcaseContent).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.DisplayShowcaseContent).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.PageTitle).HasMaxLength(255 ).IsRequired(false);
                entity.Property(x => x.Attachment).HasMaxLength(100).IsRequired(false);

                entity
                    .HasOne(b => b.CreatedUserBrand)
                    .WithMany(u => u.CreatedUserBrands)
                    .HasForeignKey(b => b.CreatedUserId);

                entity
                    .HasOne(b => b.ModifiedUserBrand)
                    .WithMany(u => u.ModifiedUserBrands)
                    .HasForeignKey(b => b.ModifiedUserId);

            });
        }

    }
}
