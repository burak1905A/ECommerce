using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ProductCommentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComments");

                entity.HasExtended();

                entity.Property(x => x.Title).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Content).HasMaxLength(65535).IsRequired(true);
                entity.Property(x => x.isAnonymous).HasMaxLength(128).IsRequired(false);
                
                entity
                .HasOne(p => p.CreatedUserProductComment)
                .WithMany(u => u.CreatedUserProductComments)
                .HasForeignKey(p => p.CreatedUserId);

                entity
                    .HasOne(p => p.ModifiedUserProductComment)
                    .WithMany(u => u.ModifiedUserProductComments)
                    .HasForeignKey(p => p.ModifiedUserId);

                entity
                 .HasOne(p => p.Member)
                 .WithMany(m => m.ProductComments)
                 .HasForeignKey(p => p.MemberId);

                entity
                .HasOne(p => p.Product)
                .WithMany(m => m.ProductComments)
                .HasForeignKey(p => p.ProductId);
            });
        }
    }
}
