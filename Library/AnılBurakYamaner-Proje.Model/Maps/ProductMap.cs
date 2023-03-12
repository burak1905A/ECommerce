using AnılBurakYamaner_Proje.Model.Entities;
using Microsoft.EntityFrameworkCore;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.FullName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Sku).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Barcode).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Tax).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.isGifted).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.Gift).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ProductDetail).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.ProductPrice).IsRequired(false);



                entity
                .HasOne(p => p.CreatedUserProduct)
                .WithMany(u => u.CreatedUserProducts)
                .HasForeignKey(p => p.CreatedUserId);

                entity
                    .HasOne(p => p.ModifiedUserProduct)
                    .WithMany(u => u.ModifiedUserProducts)
                    .HasForeignKey(p => p.ModifiedUserId);


                entity
            
                .HasOne(p => p.Category)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.CategoryId);

              
                entity
                 .HasOne(p => p.User)
                 .WithMany(m => m.Products)
                 .HasForeignKey(p => p.UserId);

                entity
                 .HasOne(p => p.Brand)
                 .WithMany(m => m.Products)
                 .HasForeignKey(p => p.BrandId);
            });
        }
    }
}
