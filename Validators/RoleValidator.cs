using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Validators
{
    public class RoleValidator
    {
        private readonly AppDbContext _context;
        public RoleValidator(AppDbContext context)
        {
            _context = context;
        }
        public async Task ValidateRoleRequest(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role Name required.");
            }

            if (await _context.Roles.AnyAsync(r => r.Role_name == roleName))
            {
                throw new ArgumentException("Role Name taken.");
            }
        }
    }
}
