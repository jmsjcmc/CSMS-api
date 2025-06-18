using Csms_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Csms_api.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyResponse> getcompany(int id);
        Task<Paginate<CompanyResponse>> allcompanies(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null);
        Task<CompanyResponse> addcompany([FromBody] CompanyRequest request);
        Task<CompanyResponse> updatecompany([FromBody] CompanyRequest request, int id);
        Task hidecompany(int id);
        Task deletecompany(int id);
    }
}
