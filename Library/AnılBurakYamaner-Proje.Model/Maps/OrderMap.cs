using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class OrderMap : IEntityBuilder
    {
             public void Build(ModelBuilder builder)
            {
                builder.Entity<Order>(entity =>
                {
                    entity.ToTable("Orders");

                    entity.HasExtended();

                    entity.Property(x => x.CustomerFirstname).HasMaxLength(255).IsRequired(true);
                    entity.Property(x => x.CustomerSurname).HasMaxLength(255).IsRequired(true);
                    entity.Property(x => x.CustomerEmail).HasMaxLength(255).IsRequired(false);
                    entity.Property(x => x.CustomerPhone).HasMaxLength(32).IsRequired(false);
                    entity.Property(x => x.PaymentTypeName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.PaymentProviderCode).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.PaymentProviderName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.PaymentGatewayCode).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.PaymentGatewayName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.BankName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.ClientIp).HasMaxLength(32).IsRequired(false);
                    entity.Property(x => x.UserAgent).HasMaxLength(1024).IsRequired(false);
                    entity.Property(x => x.Currency).HasMaxLength(32).IsRequired(true);
                    entity.Property(x => x.TransactionId).HasMaxLength(255).IsRequired(false);
                    entity.Property(x => x.ErrorMessage).HasMaxLength(65535).IsRequired(false);
                    entity.Property(x => x.Referrer).HasMaxLength(65535).IsRequired(false);
                    entity.Property(x => x.GiftNote).HasMaxLength(65535).IsRequired(false);
                    entity.Property(x => x.ShippingProviderCode).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.ShippingProviderName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.ShippingCompanyName).HasMaxLength(128).IsRequired(false);
                    entity.Property(x => x.ShippingTrackingCode).HasMaxLength(255).IsRequired(false);
                    entity.Property(x => x.Source).HasMaxLength(255).IsRequired(false);

                    entity
                    .HasOne(o => o.CreatedUserOrder)
                    .WithMany(u => u.CreatedUserOrders)
                    .HasForeignKey(o => o.CreatedUserId);

                    entity
                        .HasOne(o => o.ModifiedUserOrder)
                        .WithMany(u => u.ModifiedUserOrders)
                        .HasForeignKey(o => o.ModifiedUserId);

                    entity
                     .HasOne(o => o.User)
                     .WithMany(m => m.Orders)
                     .HasForeignKey(o => o.UserId);

                    entity
                     .HasOne(o => o.ShippingAddress)
                     .WithMany(s => s.Orders)
                     .HasForeignKey(o => o.ShippingAddressId);
                });
            }
    }
}
