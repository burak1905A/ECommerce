using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class TownMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Town>(entity =>
            {
                entity.ToTable("Towns");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
               

                entity
                .HasOne(t => t.CreatedUserTown)
                .WithMany(u => u.CreatedUserTowns)
                .HasForeignKey(t => t.CreatedUserId);

                entity
                    .HasOne(t => t.ModifiedUserTown)
                    .WithMany(u => u.ModifiedUserTowns)
                    .HasForeignKey(t => t.ModifiedUserId);

                entity
                .HasOne(t => t.Location)
                .WithMany(l => l.Towns)
                .HasForeignKey(t => t.LocationId);
            });
        }
    }
}
