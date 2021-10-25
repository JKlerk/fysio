using System;
using System.Collections.Generic;
using Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeders
{
    
    public class UserSeeder
    {
        public List<IdentityUser> Users { get; }

        public UserSeeder()
        {
            List<IdentityUser> data = new List<IdentityUser>();
            data.Add(
                new IdentityUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "therapist",
                    Email = "therapist1@fysio.nl",
                }
            );
            
            // data.Add(
            //     new IdentityUser()
            //     {
            //         Id = Guid.NewGuid().ToString(),
            //         UserName = "therapist",
            //         Email = "therapist2@fysio.nl"
            //     }
            // );
            //
            // data.Add(
            //     new IdentityUser()
            //     {
            //         Id = Guid.NewGuid().ToString(),
            //         UserName = "student",
            //         Email = "student1@fysio.nl"
            //     }
            // );
            //
            // data.Add(
            //     new IdentityUser()
            //     {
            //         Id = Guid.NewGuid().ToString(),
            //         UserName = "student",
            //         Email = "student2@fysio.nl"
            //     }
            // );

            foreach (var user in data)
            {
                user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, "password");
            }
            
            Users = data;
        }
    }
}