using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var physioRole = new IdentityRole
            {
                Name = Role.TherapistRole,
                NormalizedName = Role.TherapistRole.ToUpper(),
                Id = "5c491816-e35b-48cc-8c8b-b7b1c7df224f",
            };

            var studentRole = new IdentityRole
            {
                Name = Role.StudentRole,
                NormalizedName = Role.StudentRole.ToUpper(),
                Id = "15ed72fe-db9d-403b-beb6-8d5b8953bba6",
            };

            var clientRole = new IdentityRole
            {
                Name = Role.PatientRole,
                NormalizedName = Role.PatientRole.ToUpper(),
                Id = "ba196295-7c35-49ab-99c2-5c95e987c000",
            };

            builder.Entity<IdentityRole>().HasData(physioRole, studentRole, clientRole);

            var user1 = new IdentityUser()
            {
                NormalizedEmail = "M.GERDES@AVANS.NL",
                NormalizedUserName = "M.GERDES",
                Email = "m.gerdes@avans.nl",
                Id = "54f013a2-3d91-4257-983a-8953181cf6f9",
                EmailConfirmed = true,
                UserName = "m.gerdes",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var user2 = new IdentityUser()
            {
                NormalizedEmail = "J.SMARIUS@AVANS.NL",
                NormalizedUserName = "J.SMARIUS",
                Email = "j.smarius@avans.nl",
                Id = "4e317568-1661-4302-be84-0ea791d6a044",
                EmailConfirmed = true,
                UserName = "j.smarius",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var user3 = new IdentityUser()
            {
                NormalizedEmail = "P.STOOP@STUDENT.AVANS.NL",
                NormalizedUserName = "P.STOOP",
                Email = "p.stoop@student.avans.nl",
                Id = "0a11bbe8-f0d2-4063-b6e1-f5359adbb909",
                EmailConfirmed = true,
                UserName = "p.stoop",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            user1.PasswordHash = hasher.HashPassword(user1, "password");
            user2.PasswordHash = hasher.HashPassword(user2, "password");
            user3.PasswordHash = hasher.HashPassword(user3, "password");

            builder.Entity<IdentityUser>().HasData(user1, user2, user3);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = physioRole.Id,
                    UserId = user1.Id,
                },
                new IdentityUserRole<string>
                {
                    RoleId = physioRole.Id,
                    UserId = user2.Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = studentRole.Id,
                    UserId = user3.Id
                }
            );

        }
    }
}
