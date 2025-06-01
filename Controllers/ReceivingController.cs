using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Helpers;
using Csms_api.Models;
using Csms_api.Services;
using Csms_api.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    public class ReceivingController : BaseApiController
    {
        private readonly ReceivingValidator _receivingValidator;
        private readonly ReceivingService _receivingService;

        public ReceivingController(AppDbContext context, IMapper mapper, ReceivingValidator receivingValidator, ReceivingService receivingService) : base (context, mapper)
        {
            _receivingValidator = receivingValidator;
            _receivingService = receivingService;
        }

        [HttpGet("receiving/{id}")]
        public async Task<ActionResult<ReceivingResponse>> getreceiving(int id)
        {
            try
            {
                var receiving = await _context.Receivings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id);

                var response = _mapper.Map<ReceivingResponse>(receiving);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("receiving/product-code")]
        public async Task<ActionResult<ProductCodeResponse>> getproductcode()
        {
            try
            {
                var products = await _context.Products
                    .AsNoTracking()
                    .ToListAsync();

                var response = _mapper.Map<ProductCodeResponse>(products);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("receiving/product")]
        public async Task<ActionResult<ProductResponse>> getproductforreceiving(
            [FromQuery]string? productCode = null)
        {
            try
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Product_code == productCode);

                var response = _mapper.Map<ProductResponse>(product);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("receiving/generate-documentNo")]
        public async Task <ActionResult<DocumentNumberResponse>> generatedocumentnumber(string? category)
        {
            try
            {
                var prefix = _receivingValidator.GetPrefixByCategory(category);
                var documentNos = await _context.Receivings
                    .AsNoTracking()
                    .Include(r => r.Document)
                    .Where(r => r.Document.Document_number.StartsWith(prefix))
                    .Select(r => r.Document.Document_number)
                    .ToListAsync();

                var nextSequence = _receivingValidator.GetNextSequence(documentNos);
                var generateDocNo = $"{prefix}-0000-{nextSequence:D4}";

                var response = new DocumentNumberResponse
                {
                    Document_number = generateDocNo
                };

                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("receivings/pending")]
        public async Task<ActionResult<Paginate<ReceivingResponse>>> allpending(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _context.Receivings
                    .AsNoTracking()
                    .Include(r => r.Document)
                    .Include(r => r.Product)
                    .Include(r => r.Receiving_detail)
                    .Where(r => r.Pending)
                    .OrderByDescending(r => r.Created_on)
                    .AsQueryable();

                var totalCount = await query.CountAsync();

                var pendings = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<ReceivingResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<ReceivingResponse>
                {
                    Items = pendings,
                    Total_count = totalCount,
                    Page_number = pageNumber,
                    Page_size = pageSize
                };
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message ?? e.Message);
            }
        }

        [HttpGet("receivings")]
        public async Task<ActionResult<Paginate<ReceivingResponse>>> allreceiving(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var query = _context.Receivings
                    .AsNoTracking()
                    .Include(r => r.Document)
                    .Include(r => r.Product)
                    .Include(r => r.Receiving_detail)
                    .Where(r => !r.Removed)
                    .OrderByDescending(r => r.Created_on)
                    .AsQueryable();

                var totalCount = await query.CountAsync();

                var receivings = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<ReceivingResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<ReceivingResponse>
                {
                    Items = receivings,
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

        [HttpPost("receiving")]
        public async Task<ActionResult<ReceivingResponse>> addreceiving([FromBody] ReceivingRequest request)
        {
            try
            {
                await _receivingValidator.ValidateReceivingRequest(request);

                var document = new Document
                {
                    Document_number = request.Document_number
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();

                var receiving = _mapper.Map<Receiving>(request);
                receiving.Document_id = document.Id;
                receiving.Pending = true;

                _context.Receivings.Add(receiving);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<ReceivingResponse>(receiving);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("receiving/update-status")]
        public async Task<ActionResult<ReceivingResponse>> updatestatus(int id,
            [FromQuery] string status)
        {
            try
            {
                var receiving = await _context.Receivings
                    .FirstOrDefaultAsync(r => r.Id == id);

                _receivingService.UpdateStatus(receiving, status);
                receiving.Updated_on = TimeHelper.GetPhilippineTime();
                _context.Receivings.Update(receiving);
                await _context.SaveChangesAsync();

                var updatedReceiving = await _context.Receivings
                    .Include(r => r.Document)
                    .Include(r => r.Product)
                    .Include(r => r.Receiving_detail)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id);

                var response = _mapper.Map<ReceivingResponse>(updatedReceiving);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
