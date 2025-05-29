using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    [Route("")]
    [ApiController]
    public class ReceivingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReceivingController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                var document = new Document
                {
                    Document_number = request.Document_number
                };

                _context.Documents.Add(document);
                await _context.SaveChangesAsync();

                var receiving = _mapper.Map<Receiving>(request);
                receiving.Document_id = document.Id;

                _context.Receivings.Add(receiving);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<ReceivingResponse>(receiving);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
