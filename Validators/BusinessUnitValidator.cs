using Csms_api.Models;

namespace Csms_api.Validators
{
    public class BusinessUnitValidator
    {
        public async Task ValidateBusinessUnitRequest(BusinessUnitRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Business_unit))
            {
                throw new ArgumentException("Business Unit required.");
            }

            if (string.IsNullOrWhiteSpace(request.BusinessUnit_location))
            {
                throw new ArgumentException("Business Unit Location required.");
            }
        }
    }
}
