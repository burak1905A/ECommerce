using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class LocationMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
               
                entity
                .HasOne(l => l.CreatedUserLocation)
                .WithMany(u => u.CreatedUserLocations)
                .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(l => l.ModifiedUserLocation)
                    .WithMany(u => u.ModifiedUserLocations)
                    .HasForeignKey(l => l.ModifiedUserId);

                entity
                 .HasOne(l => l.Country)
                 .WithMany(c => c.Locations)
                 .HasForeignKey(l => l.CountryId);
            });
        }
    }
}
