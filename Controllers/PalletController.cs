using AutoMapper;
using Csms_api.Helpers;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    [Route("")]
    [ApiController]
    public class PalletController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PalletController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("pallet/{id}")]
        public async Task<ActionResult<PalletResponse>> getpallet(int id)
        {
            try
            {
                var pallet = await _context.Pallets
                    .FirstOrDefaultAsync(p => p.Id == id);

                var response = _mapper.Map<PalletResponse>(pallet);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("pallet")]
        public async Task<ActionResult<PalletResponse>> addpallet([FromBody] PalletRequest request)
        {
            try
            {
                var pallet = _mapper.Map<Pallet>(request);

                _context.Pallets.Add(pallet);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<PalletResponse>(pallet);
                return response;
            } catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("pallet/{id}")]
        public async Task<ActionResult> removepallet(int id)
        {
            try
            {
                var pallet = await _context.Pallets
                    .FirstOrDefaultAsync(p => p.Id == id);

                pallet.Removed = true;
                pallet.Updated_on = TimeHelper.GetPhilippineTime();

                _context.Pallets.Update(pallet);
                await _context.SaveChangesAsync();

                return Ok("Pallet removed.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("pallet/{id}")]
        public async Task<ActionResult> deletepallet(int id)
        {
            try
            {
                var pallet = await _context.Pallets
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.Pallets.Remove(pallet);
                await _context.SaveChangesAsync();

                return Ok("Pallet removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
