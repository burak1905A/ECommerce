using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ProductPriceMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("ProductPrices");

                entity.HasExtended();

                entity.Property(x => x.Value).IsRequired(false);
                entity.Property(x => x.Type).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Type).IsRequired(false);

                entity
                .HasOne(p => p.CreatedUserProductPrice)
                .WithMany(u => u.CreatedUserProductPrices)
                .HasForeignKey(p => p.CreatedUserId);

                entity
                    .HasOne(p => p.ModifiedUserProductPrice)
                    .WithMany(u => u.ModifiedUserProductPrices)
                    .HasForeignKey(p => p.ModifiedUserId);

                entity
                .HasOne(p => p.Product)
                .WithMany(m => m.ProductPrices)
                .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
