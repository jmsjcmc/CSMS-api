using AutoMapper;
using Csms_api.Helpers;
using Csms_api.Helpers.Queries;
using Csms_api.Interfaces;
using Csms_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyQueries _companyQueries;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService(CompanyQueries companyQueries, AppDbContext context, IMapper mapper)
        {
            _companyQueries = companyQueries;
            _context = context;
            _mapper = mapper;
        }
        // [HttpGet("company/{id}")]
        public async Task<CompanyResponse> getcompany(int id)
        {
            var company = _companyQueries.getmethodcompany(id);
            return _mapper.Map<CompanyResponse>(company);
        }
        // [HttpGet("companies")]
        public async Task<Paginate<CompanyResponse>> allcompanies(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null)
        {
            var query = _companyQueries.companies(searchTerm);
            var totalCount = await query.CountAsync();
            var companies = await PaginationHelper.paginateandproject<Company, CompanyResponse>(
                query, pageNumber, pageSize, _mapper);
            return PaginationHelper.paginatedresponse(companies, totalCount, pageNumber, pageSize);
        }
        // [HttpPost("company")]
        public async Task<CompanyResponse> addcompany([FromBody] CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            company.Created_on = TimeHelper.GetPhilippineTime();

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            var savedCompany = _companyQueries.getmethodcompany(company.Id);
            return _mapper.Map<CompanyResponse>(savedCompany);
        }
        // [HttpPatch("company/update/{id}")]
        public async Task<CompanyResponse> updatecompany([FromBody] CompanyRequest request, int id)
        {
            var company = await _companyQueries.patchmethodcompany(id);

            _mapper.Map(request, company);
            company.Updated_on = TimeHelper.GetPhilippineTime();

            var updatedCompany = _companyQueries.getmethodcompany(company.Id);
            return _mapper.Map<CompanyResponse>(updatedCompany);
        }
        // [HttpPatch("company/hide/{id}")]
        public async Task hidecompany(int id)
        {
            var company = await _companyQueries.patchmethodcompany(id);
            company.Removed = true;
            company.Updated_on = TimeHelper.GetPhilippineTime();

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }
        // [HttpDelete("company/delete/{id}")]
        public async Task deletecompany(int id)
        {
            var company = await _companyQueries.patchmethodcompany(id);

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
