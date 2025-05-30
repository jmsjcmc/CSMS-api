using Csms_api.Models;

namespace Csms_api.Validators
{
    public class RoleValidator
    {
        public async Task ValidateRoleRequest(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role Name required.");
            }
        }
    }
}
