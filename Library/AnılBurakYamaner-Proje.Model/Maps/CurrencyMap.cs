using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CurrencyMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currencys");

                entity.HasExtended();

                entity.Property(x => x.Label).HasMaxLength(50).IsRequired(false);
                

                entity
                .HasOne(c => c.CreatedUserCurrency)
                .WithMany(u => u.CreatedUserCurrencys)
                .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCurrency)
                    .WithMany(u => u.ModifiedUserCurrencys)
                    .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
