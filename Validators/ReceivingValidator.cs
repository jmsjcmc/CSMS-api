using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Validators
{
    public class ReceivingValidator
    {
        private readonly AppDbContext _context;
        public ReceivingValidator(AppDbContext context)
        {
            _context = context;
        }

        public async Task ValidateReceivingRequest(ReceivingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Category))
            {
                throw new ArgumentException("Category required.");
            }

            if (string.IsNullOrWhiteSpace(request.Document_number))
            {
                throw new ArgumentException("Document Number required.");
            }

            if (await _context.Documents.AnyAsync(d => d.Document_number == request.Document_number))
            {
                throw new ArgumentException("Document Number taken.");
            }

            if (request.Product_id <= 0)
            {
                throw new ArgumentException("Product Id required and must be valid identifier.");
            }

            if (string.IsNullOrWhiteSpace(request.Expiration_date))
            {
                throw new ArgumentException("Expiration Date required.");
            }

            if (string.IsNullOrWhiteSpace(request.Cv_number))
            {
                throw new ArgumentException("CV Number required.");
            }

            if (string.IsNullOrWhiteSpace(request.Plate_number))
            {
                throw new ArgumentException("Plate Number required.");
            }

            if (string.IsNullOrWhiteSpace(request.Arrival_date))
            {
                throw new ArgumentException("Arrival Date required.");
            }

            if (string.IsNullOrWhiteSpace(request.Unloading_start))
            {
                throw new ArgumentException("Unloading Start required.");
            }

            if (string.IsNullOrWhiteSpace(request.Unloading_end))
            {
                throw new ArgumentException("Unloading End required.");
            }

            if (request.Overall_weight <= 0)
            {
                throw new ArgumentException("Over All Weight required and must be greater than zero.");
            }
        }

        public async Task ValidateCategoryRequest(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Category required.");
            }
        }

        public string? GetPrefixByCategory(string category) =>
          category.Trim().ToLower() switch
          {
              "raw mats" => "R2",
              "fresh goods" => "R3",
              _ => null
          };

        public int GetNextSequence(IEnumerable<string> documetnNos)
        {
            return documetnNos
                .Select(doc =>
                {
                    var parts = doc.Split('-');
                    return parts.Length == 3 && int.TryParse(parts[2], out var number) ? number : 0;
                })
                .DefaultIfEmpty(0)
                .Max() + 1;
        }
    }
}
