using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class MemberMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Member>(entity =>
            {
                entity.ToTable("Members");

                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.SurName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Email).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Birthdate).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.PhoneNumber).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.MobilePhoneNumber).HasMaxLength(255).IsRequired(true );
                entity.Property(x => x.OtherLocation).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Address).HasMaxLength(65535).IsRequired(false);
                entity.Property(x => x.TaxNumber).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.TcId).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.ZipCode).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.TaxOffice).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.LastMailSentDate).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.District).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.DeviceType).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.DeviceInfo).HasMaxLength(65535).IsRequired(false);

                entity
                .HasOne(m => m.CreatedUserMember)
                .WithMany(u => u.CreatedUserMembers)
                .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(m => m.ModifiedUserMember)
                    .WithMany(u => u.ModifiedUserMembers)
                    .HasForeignKey(c => c.ModifiedUserId);

                entity
                 .HasOne(m => m.Country)
                 .WithMany(c => c.Members)
                 .HasForeignKey(m => m.CountryId);

                entity
                 .HasOne(m => m.Location)
                 .WithMany(l => l.Members)
                 .HasForeignKey(m => m.LocationId);
            });
        }
    }
}
