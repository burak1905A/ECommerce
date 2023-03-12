using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class OrderDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");

                entity.HasExtended();

                entity.Property(x => x.varKey).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.varValue).HasMaxLength(65535).IsRequired(true);
                

                entity
                .HasOne(o => o.CreatedUserOrderDetail)
                .WithMany(u => u.CreatedUserOrderDetails)
                .HasForeignKey(o => o.CreatedUserId);

                entity
                    .HasOne(o => o.ModifiedUserOrderDetail)
                    .WithMany(u => u.ModifiedUserOrderDetails)
                    .HasForeignKey(o => o.ModifiedUserId);

            });
        }
    }
}
