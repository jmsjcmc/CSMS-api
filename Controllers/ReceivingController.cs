using AutoMapper;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("receiving")]
        public async Task<ActionResult<ReceivingResponse>> addreceiving([FromBody] ReceivingRequest request)
        {
            try
            {
                var receiving = _mapper.Map<Receiving>(request);

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
