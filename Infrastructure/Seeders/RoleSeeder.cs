using System;
using System.Collections.Generic;
using Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeders
{
    public class RoleSeeder
    {
        public List<IdentityRole> roles { get; }

        public RoleSeeder()
        {
            List<IdentityRole> data = new List<IdentityRole>();
            data.Add(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Role.AdminRole,
                    NormalizedName = Role.AdminRole.ToUpper()
                }
            );
            data.Add(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Role.PatientRole,
                    NormalizedName = Role.PatientRole.ToUpper()
                }
            );
            data.Add(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Role.StudentRole,
                    NormalizedName = Role.StudentRole.ToUpper()
                }
            );
            data.Add(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Role.TherapistRole,
                    NormalizedName = Role.TherapistRole.ToUpper()
                }
            );
            
            roles = data;
        }
    }
}