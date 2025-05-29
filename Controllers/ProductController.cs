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
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ExcelHelper _excelHelper;

        public ProductController(AppDbContext context, IMapper mapper, ExcelHelper excelHelper)
        {
            _context = context;
            _mapper = mapper;
            _excelHelper = excelHelper;
        }

        [HttpGet("products/template")]
        public async Task<ActionResult> template()
        {
            try
            {
                var file = _excelHelper.generateproducttemplate();
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductTemplate.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("products/export")]
        public async Task<ActionResult> export()
        {
            try
            {
                var products = await _context.Products
                    .ToListAsync();
                var file = await _excelHelper.exportproducts(products);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductResponse>> getproduct(int id)
        {
            try
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .Include(p => p.Company)
                    .FirstOrDefaultAsync(p => p.Id == id);

                var response = _mapper.Map<ProductResponse>(product);
                return response;

            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("products")]
        public async Task<ActionResult<Paginate<ProductResponse>>> allproducts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var query = _context.Products
                    .AsNoTracking()
                    .Include(p => p.Company)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(p => p.Product_code == searchTerm || p.Product_name == searchTerm);
                }

                var totalCount = await query.CountAsync();

                var products = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<ProductResponse>
                {
                    Items = products,
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

        [HttpPost("products/import")]
        public async Task<ActionResult> importproducts(IFormFile file)
        {
            try
            {
                var products = await _excelHelper.importproducts(file);
                await _context.Products.AddRangeAsync(products);
                await _context.SaveChangesAsync();

                return Ok("Products imported.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("product")]
        public async Task<ActionResult<ProductResponse>> addproduct([FromBody] ProductRequest request)
        {
            try
            {
                var product = _mapper.Map<Product>(request);

                product.Created_on = TimeHelper.GetPhilippineTime();

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<ProductResponse>(product);

                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("product/{id}")]
        public async Task<ActionResult> hideproduct (int id)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == id);

                product.Removed = true;
                product.Updated_on = TimeHelper.GetPhilippineTime();

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return Ok("Product removed.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("product/{id}")]
        public async Task<ActionResult> deleteproduct (int id)
        {
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return Ok("Product removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
