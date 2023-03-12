using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class OrderItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItems");

                entity.HasExtended();

                entity.Property(x => x.ProductName).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ProductSku).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.ProductBarcode).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ProductPrice).HasMaxLength(65535).IsRequired(false);


                entity
                .HasOne(o => o.CreatedUserOrderItem)
                .WithMany(u => u.CreatedUserOrderItems)
                .HasForeignKey(o => o.CreatedUserId);

                entity
                    .HasOne(o => o.ModifiedUserOrderItem)
                    .WithMany(u => u.ModifiedUserOrderItems)
                    .HasForeignKey(o => o.ModifiedUserId);

                
                entity
                 .HasOne(l => l.Order)
                 .WithMany(c => c.OrderItems)
                 .HasForeignKey(l => l.OrderId);

                entity
                .HasOne(l => l.Product)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(l => l.ProductId);

            });
        }
    }
}
