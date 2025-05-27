using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Helpers;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    [Route("")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ExcelHelper _excelHelper;
        public CompanyController(AppDbContext context, IMapper mapper, ExcelHelper excelHelper)
        {
            _context = context;
            _mapper = mapper;
            _excelHelper = excelHelper;
        }

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

        [HttpGet("company/{id}")]
        public async Task<ActionResult<CompanyResponse>> getcompany(int id)
        {
            try
            {
                var company = await _context.Companies
                    .FindAsync(id);

                var response = _mapper.Map<CompanyResponse>(company);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("companies")]
        public async Task<ActionResult<Paginate<CompanyResponse>>> allcompanies(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var query = _context.Companies
                    .AsNoTracking()
                    .OrderByDescending(c => c.Id)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(c => c.Company_name == searchTerm);
                }

                var totalCount = await query.CountAsync();

                var companies = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<CompanyResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<CompanyResponse>
                {
                    Items = companies,
                    Total_count = totalCount,
                    Page_number = pageNumber,
                    Page_size = pageSize
                };

                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

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

        [HttpPost("company")]
        public async Task<ActionResult<CompanyResponse>> addcompany([FromBody] CompanyRequest request)
        {
            try
            {
                var company = _mapper.Map<Company>(request);
                company.Created_on = TimeHelper.GetPhilippineTime();
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<CompanyResponse>(company);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("company")]
        public async Task<ActionResult> hidecompany(int id)
        {
            try
            {
                var company = await _context.Companies
                    .FirstOrDefaultAsync(c => c.Id == id);

                company.Removed = true;
                company.Updated_on = TimeHelper.GetPhilippineTime();

                _context.Companies.Update(company);
                await _context.SaveChangesAsync();

                return Ok("Company removed.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }


        [HttpDelete("company/{id}")]
        public async Task<ActionResult> deletecompany(int id)
        {
            try
            {
                var company = await _context.Companies
                    .FindAsync(id);

                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();

                return Ok("Company removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
