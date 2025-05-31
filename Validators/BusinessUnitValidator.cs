using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Validators
{
    public class BusinessUnitValidator
    {
        private readonly AppDbContext _context;

        public BusinessUnitValidator(AppDbContext context)
        {
            _context = context;
        }
        public async Task ValidateBusinessUnitRequest(BusinessUnitRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Business_unit))
            {
                throw new ArgumentException("Business Unit required.");
            }

            if (await _context.BusinessUnits.AnyAsync(b => b.Business_unit == request.Business_unit))
            {
                throw new ArgumentException("Business Unit taken.");
            }

            if (string.IsNullOrWhiteSpace(request.BusinessUnit_location))
            {
                throw new ArgumentException("Business Unit Location required.");
            }
        }
    }
}
