using AnılBurakYamaner_Proje.Model.Entities;
using AnılBurakYamaner_Proje.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnılBurakYamaner_Proje.Model.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("701c99ed-d446-472f-a53d-31dde4605a15"),
                    Status = Status.Active,
                    Email = "admin@admin.com",
                    Password = "123",
                    FirstName = "admin",
                    LastName = "admin",
                    Title = "Admin",
                    ImageUrl = "/",
                    LastIPAddress = "127.0.0.1",
                    IsAdmin = true,
                }); ; 
        }
    }
}
