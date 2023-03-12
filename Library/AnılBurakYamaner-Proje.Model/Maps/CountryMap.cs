using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CountryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Code).HasMaxLength(255).IsRequired(true);

                entity
                   .HasOne(c => c.CreatedUserCountry)
                   .WithMany(u => u.CreatedUserCountries)
                   .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCountry)
                    .WithMany(u => u.ModifiedUserCountries)
                    .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
