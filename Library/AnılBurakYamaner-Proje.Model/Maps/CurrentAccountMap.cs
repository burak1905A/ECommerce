using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CurrentAccountMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CurrentAccount>(entity =>
            {
                entity.ToTable("CurrentAccounts");

                entity.HasExtended();

                entity.Property(x => x.Code).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Title).HasMaxLength(255).IsRequired(false);
            
               

                entity
                .HasOne(c => c.CreatedUserCurrentAccount)
                .WithMany(u => u.CreatedUserCurrentAccounts)
                .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCurrentAccount)
                    .WithMany(u => u.ModifiedUserCurrentAccounts)
                    .HasForeignKey(c => c.ModifiedUserId);

                entity
                 .HasOne(c => c.Member)
                 .WithMany(m => m.CurrentAccounts)
                 .HasForeignKey(c => c.MemberId);
            });
        }
    }
}
