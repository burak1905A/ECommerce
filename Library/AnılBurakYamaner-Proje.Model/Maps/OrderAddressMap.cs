using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class OrderAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderAddress>(entity =>
            {
                entity.ToTable("OrderAddresses");

                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.SurName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Country).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.Location).HasMaxLength(128).IsRequired(true);
                entity.Property(x => x.SubLocation).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Address).HasMaxLength(65535).IsRequired(true);
                entity.Property(x => x.PhoneNumber).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.MobilePhoneNumber).HasMaxLength(32).IsRequired(false);


                entity
                .HasOne(o => o.CreatedUserOrderAddress)
                .WithMany(u => u.CreatedUserOrderAddresses)
                .HasForeignKey(o => o.CreatedUserId);

                entity
                    .HasOne(o => o.ModifiedUserOrderAddress)
                    .WithMany(u => u.ModifiedUserOrderAddresses)
                    .HasForeignKey(o => o.ModifiedUserId);

               
            });
        }
    }
}
