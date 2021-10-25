using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeders
{
    public class RoleUserSeeder
    {
        public List<IdentityUserRole<string>> UserRoles { get; }

        public RoleUserSeeder(List<IdentityUser> users, List<IdentityRole> roles)
        {
            List<IdentityUserRole<string>> data = new List<IdentityUserRole<string>>();
            
            
            // data.Add(
            //     new IdentityUserRole<string>
            //     {
            //         UserId = users.First(x => x.UserName == "therapist").Id,
            //         RoleId = roles.First(x => x.Name == Role.TherapistRole).Id
            //     }
            // );
            //
            // data.Add(
            //     new IdentityUserRole<string>
            //     {
            //         UserId = users.Last(x => x.UserName == "therapist").Id,
            //         RoleId = roles.First(x => x.Name == Role.TherapistRole).Id
            //     }
            // );
            //
            // data.Add(
            //     new IdentityUserRole<string>
            //     {
            //         UserId = users.First(x => x.UserName == "student").Id,
            //         RoleId = roles.First(x => x.Name == Role.StudentRole).Id
            //     }
            // );
            //
            // data.Add(
            //     new IdentityUserRole<string>
            //     {
            //         UserId = users.Last(x => x.UserName == "student").Id,
            //         RoleId = roles.First(x => x.Name == Role.StudentRole).Id
            //     }
            // );

            UserRoles = data;
        }
    }
}