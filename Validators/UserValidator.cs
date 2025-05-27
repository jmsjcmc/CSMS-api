using Csms_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Csms_api.Validators
{
    public class UserValidator
    {
        private readonly AppDbContext _context;
        public UserValidator(AppDbContext context)
        {
            _context = context;
        }
        public async Task ValidateUserRequest(UserRequest request)
        {
            var trimmedRoles = request.Roles.Select(r => r.Trim()).ToList();
            var existingRoles = await _context.Roles
                .Where(r => trimmedRoles.Contains(r.Role_name))
                .Select(r => r.Role_name)
                .ToListAsync();

            var invalidRoles = trimmedRoles.Except(existingRoles).ToList();

            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                throw new ArgumentException("Username taken.");
            }

            if (string.IsNullOrWhiteSpace(request.First_name))
            {
                throw new ArgumentException("First Name required.");
            }

            if (string.IsNullOrWhiteSpace(request.Last_name))
            {
                throw new ArgumentException("Last Name required.");
            }

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new ArgumentException("Username required.");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new ArgumentException("Password required.");
            }

            if (request.Password.Length < 6)
            {
                throw new ArgumentException("Password must be atleast 6 character long.");
            }

            if (!strongPassword(request.Password))
            {
                throw new ArgumentException("Password must include uppercase, lowercase, number, and special character. ");
            }

            if (string.IsNullOrWhiteSpace(request.Position))
            {
                throw new ArgumentException("Position required.");
            }

            if (string.IsNullOrWhiteSpace(request.Department))
            {
                throw new ArgumentException("Department required.");
            }

            if (request.Roles == null || !request.Roles.Any())
            {
                throw new ArgumentException("Atleast one role must be assigned.");
            }

            if (request.BusinessUnit_id <= 0)
            {
                throw new ArgumentException("Valid Business Unit required.");
            }

            if (invalidRoles.Any())
            {
                throw new ArgumentException($"Invalid roles: {string.Join(", ", invalidRoles)}");
            }
        }

        private static bool strongPassword(string password)
        {
            // Atleast 1 uppercase, 1 lowercase, 1 digit, 1 special character
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$");
            return regex.IsMatch(password);
        }
    }
}
