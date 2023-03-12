using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class ShippingAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ShippingAddress>(entity =>
            {
                entity.ToTable("ShippingAddresses");

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
                .HasOne(s => s.CreatedUserShippingAddress)
                .WithMany(u => u.CreatedUserShippingAddresses)
                .HasForeignKey(s => s.CreatedUserId);

                entity
                    .HasOne(s => s.ModifiedUserShippingAddress)
                    .WithMany(u => u.ModifiedUserShippingAddresses)
                    .HasForeignKey(s => s.ModifiedUserId);

               
            });
        }
    }
}
