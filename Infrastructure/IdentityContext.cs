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

            var patientRole = new IdentityRole
            {
                Name = Role.PatientRole,
                NormalizedName = Role.PatientRole.ToUpper(),
                Id = "ba196295-7c35-49ab-99c2-5c95e987c000",
            };

            builder.Entity<IdentityRole>().HasData(physioRole, studentRole, patientRole);

            var user1 = new IdentityUser()
            {
                NormalizedEmail = "A.BIYIKLI@AVANS.NL",
                Email = "a.biyikli@avans.nl",
                Id = "54f013a2-3d91-4257-983a-8953181cf6f9",
                EmailConfirmed = true,
                UserName = "a.biyikli",
                NormalizedUserName = "A.BIYIKLI",
                
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var user2 = new IdentityUser()
            {
                NormalizedEmail = "P.STOOP@AVANS.NL",
                Email = "p.stoop@avans.nl",
                Id = "4e317568-1661-4302-be84-0ea791d6a044",
                EmailConfirmed = true,
                UserName = "p.stoop",
                NormalizedUserName = "P.STOOP",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            user1.PasswordHash = hasher.HashPassword(user1, "password");
            user2.PasswordHash = hasher.HashPassword(user2, "password");

            builder.Entity<IdentityUser>().HasData(user1, user2);

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
                }
            );

        }
    }
}
