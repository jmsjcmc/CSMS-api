using AutoMapper;
using Csms_api.Helpers.Queries;
using Csms_api.Interfaces;
using Csms_api.Models;

namespace Csms_api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyQueries _companyQueries;
        private readonly IMapper _mapper;
        public CompanyService(CompanyQueries companyQueries, IMapper mapper)
        {
            _companyQueries = companyQueries;
            _mapper = mapper;
        }
        public async Task<CompanyResponse> getcompany(int id)
        {
            var company = _companyQueries.getmethodcompany(id);
            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task<Paginate<CompanyResponse>> allcompanies(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null)
        {

        }
    }
}
