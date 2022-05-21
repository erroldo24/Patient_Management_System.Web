﻿using Patient_Management_System.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Patient_Management_System.Web.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                 new IdentityRole
                 {
                     Id = "eba7548ff-da7d-475a-b17c-a200ad79f77a",
                     Name = Roles.User,
                     NormalizedName = Roles.User.ToUpper()
                 }

            );
        }
    }
}