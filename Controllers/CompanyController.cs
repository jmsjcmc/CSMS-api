using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Helpers;
using Csms_api.Models;
using Csms_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly ExcelHelper _excelHelper;
        private readonly CompanyService _companyService;
        public CompanyController(AppDbContext context, IMapper mapper, ExcelHelper excelHelper, CompanyService companyService) : base(context, mapper)
        {
            _excelHelper = excelHelper;
            _companyService = companyService;
        }
        // Generate companies template
        [HttpGet("companies/template")]
        public async Task<ActionResult> template()
        {
            try
            {
                var file = _excelHelper.generatecompanytemplate();
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CompanyTemplate.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Export companies
        [HttpGet("companies/export")]
        public async Task<ActionResult> export()
        {
            try
            {
                var companies = await _context.Companies
                    .ToListAsync();

                var file = _excelHelper.exportcompanies(companies);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Companies.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Fetch specific company
        [HttpGet("company/{id}")]
        public async Task<ActionResult<CompanyResponse>> getcompany(int id)
        {
            try
            {
                var response = await _companyService.getcompany(id);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Fetch all companies with optional filter for company name
        [HttpGet("companies")]
        public async Task<ActionResult<Paginate<CompanyResponse>>> allcompanies(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var response = await _companyService.allcompanies(pageNumber, pageSize, searchTerm);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Import companies
        [HttpPost("companies/import")]
        public async Task<ActionResult> importcompanies(IFormFile file)
        {
            try
            {
                var companies = _excelHelper.importcompanies(file);
                await _context.Companies.AddRangeAsync(companies);
                await _context.SaveChangesAsync();

                return Ok("Companies imported.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Create company
        [HttpPost("company")]
        public async Task<ActionResult<CompanyResponse>> addcompany([FromBody] CompanyRequest request)
        {
            try
            {
                var response = await _companyService.addcompany(request);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Update specific company
        [HttpPatch("company/update/{id}")]
        public async Task<ActionResult<CompanyResponse>> updatecompany([FromBody] CompanyRequest request, int id)
        {
            try
            {
                var response = await _companyService.updatecompany(request, id);
                return response;
            } catch (Exception e)
            {
                return handleexception(e);
            }
        }
        // Hide specific company without removing in Database (soft delete)
        [HttpPatch("company/hide/{id}")]
        public async Task<ActionResult> hidecompany(int id)
        {
            try
            {
                await _companyService.hidecompany(id);
                return Ok("Success");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
        // Delete specific company in Database
        [HttpDelete("company/delete/{id}")]
        public async Task<ActionResult> deletecompany(int id)
        {
            try
            {
                await _companyService.deletecompany(id);
                return Ok("Success");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
