using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CartMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Cart>(entity =>
            {
                entity.ToTable("Carts");

                entity.HasExtended();

                entity.Property(x => x.SessionId).HasMaxLength(255).IsRequired(true);
               

                entity
                    .HasOne(c => c.CreatedUserCart)
                    .WithMany(u => u.CreatedUserCarts)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCart)
                    .WithMany(u => u.ModifiedUserCarts)
                    .HasForeignKey(c => c.ModifiedUserId);

                entity
                    .HasOne(c => c.User)
                    .WithMany(m => m.Carts)
                    .HasForeignKey(c => c.UserId);
            });
        }
    }
}
