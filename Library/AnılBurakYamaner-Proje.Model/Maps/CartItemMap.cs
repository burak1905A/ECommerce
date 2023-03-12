using AnılBurakYamaner_Proje.Core.Map;
using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.Maps
{
    public class CartItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");

                entity.HasExtended();

                            

                entity
                    .HasOne(c => c.CreatedUserCartItem)
                    .WithMany(u => u.CreatedUserCartItems)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                    .HasOne(c => c.ModifiedUserCartItem)
                    .WithMany(u => u.ModifiedUserCartItems)
                    .HasForeignKey(c => c.ModifiedUserId);

                entity
                    .HasOne(c => c.Cart)
                    .WithMany(k => k.CartItems)
                    .HasForeignKey(c => c.CartId);

                

            });
        }
    }
}
