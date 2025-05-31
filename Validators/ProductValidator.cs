using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Validators
{
    public class ProductValidator
    {
        private readonly AppDbContext _context;
        public ProductValidator(AppDbContext context)
        {
            _context = context;
        }
        public async Task ValidateProductRequest(ProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Product_code))
            {
                throw new ArgumentException("Product Code required.");
            }

            if (await _context.Products.AnyAsync(p => p.Product_code == request.Product_code))
            {
                throw new ArgumentException("Product Code taken.");
            }

            if (string.IsNullOrWhiteSpace(request.Product_name))
            {
                throw new ArgumentException("Product Name required.");
            }

            if (string.IsNullOrWhiteSpace(request.Variant))
            {
                throw new ArgumentException("Variant required.");
            }

            if (string.IsNullOrWhiteSpace(request.Sku))
            {
                throw new ArgumentException("Sku required.");
            }

            if (string.IsNullOrWhiteSpace(request.Product_packaging))
            {
                throw new ArgumentException("Product Packaging required.");
            }

            if (string.IsNullOrWhiteSpace(request.Delivery_unit))
            {
                throw new ArgumentException("Delivery Unit required.");
            }

            if (request.Quantity <= 0)
            {
                throw new ArgumentException("Quantity required and must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(request.Uom))
            {
                throw new ArgumentException("Unit Of Measurement required.");
            } 

            if (request.Weight <= 0)
            {
                throw new ArgumentException("Weight required and must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(request.Unit))
            {
                throw new ArgumentException("Unit required.");
            }

            if (request.Company_id <= 0)
            {
                throw new ArgumentException("Company Id required and must be valid identifier.");
            }
        }
    }
}
