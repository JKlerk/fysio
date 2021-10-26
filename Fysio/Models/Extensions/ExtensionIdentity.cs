using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Core.Domain;

namespace Fysio.Models.Extensions
{
    public static class ExtensionIdentity
    {
        public static bool IsInAnyRole(this IPrincipal user, params string[] roles)
        {
            return roles.Any(user.IsInRole);
        }
    }
}