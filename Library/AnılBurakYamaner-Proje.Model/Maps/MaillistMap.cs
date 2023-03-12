using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class MaillistMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Maillist>(entity =>
            {
                entity.ToTable("Maillists");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Email).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.CreatorIpAddress).HasMaxLength(64).IsRequired(false);
               

                entity
                .HasOne(m => m.CreatedUserMaillist)
                .WithMany(u => u.CreatedUserMaillists)
                .HasForeignKey(m => m.CreatedUserId);

                entity
                    .HasOne(m => m.ModifiedUserMaillist)
                    .WithMany(u => u.ModifiedUserMaillists)
                    .HasForeignKey(m => m.ModifiedUserId);

            });
        }
    }
}
