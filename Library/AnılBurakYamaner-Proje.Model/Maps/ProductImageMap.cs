using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ProductImageMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImages");

                entity.HasExtended();

                entity.Property(x => x.FileName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Extension).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.DirectoryName).HasMaxLength(10).IsRequired(false);
                entity.Property(x => x.Revision).HasMaxLength(30).IsRequired(false);
              
                entity
                .HasOne(p => p.CreatedUserProductImage)
                .WithMany(u => u.CreatedUserProductImages)
                .HasForeignKey(p => p.CreatedUserId);

                entity
                    .HasOne(p => p.ModifiedUserProductImage)
                    .WithMany(u => u.ModifiedUserProductImages)
                    .HasForeignKey(p => p.ModifiedUserId);

                entity
                .HasOne(p => p.Product)
                .WithMany(m => m.ProductImages)
                .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
