using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class UserRepository
    {
        private IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }

        public void AddUserRole(IdentityUserRole<string> userRole)
        {
            _context.UserRoles.Add(userRole);
        }
    }
}