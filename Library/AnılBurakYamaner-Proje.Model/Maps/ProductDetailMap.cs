using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ProductDetailMap : IEntityBuilder
    {
    public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetails");

                entity.HasExtended();

                entity.Property(x => x.Sku).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Details).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.ExtraDetails).HasMaxLength(65535).IsRequired(false);
            

                entity
                .HasOne(p => p.CreatedUserProductDetail)
                .WithMany(u => u.CreatedUserProductDetails)
                .HasForeignKey(p => p.CreatedUserId);

                entity
                    .HasOne(p => p.ModifiedUserProductDetail)
                    .WithMany(u => u.ModifiedUserProductDetails)
                    .HasForeignKey(p => p.ModifiedUserId);

                entity
                .HasOne(p => p.Product)
                .WithMany(m => m.ProductDetails)
                .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
