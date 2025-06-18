using AutoMapper;
using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Helpers.Queries
{
    public class CompanyQueries : BaseApiController
    {
        public CompanyQueries(AppDbContext context, IMapper mapper) : base (context, mapper)
        {
            
        }
        // Query for fetching all companies with optional searchterm for company name
        public IQueryable<Company> companies(string? searchTerm = null)
        {
            var query = _context.Companies
                .AsNoTracking()
                .Include(c => c.Product)
                .OrderByDescending(c => c.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => c.Company_name == searchTerm);
            }

            return query;
        }
        // Query for fetching all companies in list
        public async Task<List<Company>> companylist()
        {
            return await _context.Companies
                .AsNoTracking()
                .Include(c => c.Product)
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }
        // Query for fetching specific company for GET method
        public async Task<Company?> getmethodcompany(int id)
        {
            return await _context.Companies
                .AsNoTracking()
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        // Query for fetching specific company for PUT/PATCH/DELETE methods
        public async Task<Company?> patchmethodcompany(int id)
        {
            return await _context.Companies
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
