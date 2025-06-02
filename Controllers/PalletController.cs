using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Helpers;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Controllers
{
    public class PalletController : BaseApiController
    {
        private readonly ExcelHelper _excelHelper;
        public PalletController(AppDbContext context, IMapper mapper, ExcelHelper excelHelper) : base(context, mapper)
        {
            _excelHelper = excelHelper;
        }
        [HttpGet("pallets/template")]
        public async Task<ActionResult> template()
        {
            try
            {
                var file = _excelHelper.generatepallettemplate();
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PalletTemplate.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("pallets/export")]
        public async Task<ActionResult> export()
        {
            try
            {
                var pallets = await _context.Pallets
                    .ToListAsync();

                var file = _excelHelper.exportpallets(pallets);
                return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Pallets.xlsx");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("cold-storage/{id}")]
        public async Task<ActionResult<ColdStorageResponse>> getstorage(int id)
        {
            try
            {
                var cs = await _context.ColdStorages
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);

                var response = _mapper.Map<ColdStorageResponse>(cs);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("pallet/{id}")]
        public async Task<ActionResult<PalletResponse>> getpallet(int id)
        {
            try
            {
                var pallet = await _context.Pallets
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                var response = _mapper.Map<PalletResponse>(pallet);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("pallet-position/{id}")]
        public async Task<ActionResult<PositionResponse>> getposition (int id)
        {
            try
            {
                var position = await _context.PalletPositions
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                var response = _mapper.Map<PositionResponse>(position);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("cold-storages")]
        public async Task<ActionResult<List<ColdStorageResponse>>> allcs()
        {
            try
            {
                var coldStorage = await _context.ColdStorages
                    .AsNoTracking()
                    .Where(c => c.Active)
                    .ToListAsync();

                var response = _mapper.Map<List<ColdStorageResponse>>(coldStorage);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("pallets")]
        public async Task<ActionResult<Paginate<PalletResponse>>> allpallets(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var query = _context.Pallets
                    .AsNoTracking()
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(p => p.Pallet_no.ToString() == searchTerm);
                }

                var totalCount = await query.CountAsync();

                var pallets = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<PalletResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<PalletResponse>
                {
                    Items = pallets,
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

        [HttpGet("pallet-positions")]
        public async Task<ActionResult<List<PositionResponse>>> allpositions()
        {
            try
            {
                var positions = await _context.PalletPositions
                    .AsNoTracking()
                    .ToListAsync();

                var response = _mapper.Map<List<PositionResponse>>(positions);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("pallets/import")]
        public async Task<ActionResult> importpallets(IFormFile file)
        {
            try
            {
                var pallets = _excelHelper.importpallets(file);
                await _context.Pallets.AddRangeAsync(pallets);
                await _context.SaveChangesAsync();

                return Ok("Pallets imported.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("cold-storage")]
        public async Task<ActionResult<ColdStorageResponse>> addstorage([FromBody] ColdstorageRequest request)
        {
            try
            {
                var coldStorage = _mapper.Map<ColdStorage>(request);

                _context.ColdStorages.Add(coldStorage);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<ColdStorageResponse>(coldStorage);
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

        [HttpPost("pallet-position")]
        public async Task<ActionResult<PositionResponse>> addposition([FromBody] PositionRequest request)
        {
            try
            {
                var position = _mapper.Map<PalletPosition>(request);

                _context.PalletPositions.Add(position);
                await _context.SaveChangesAsync();

                var savedPosition = await _context.PalletPositions
                    .AsNoTracking()
                    .Include(p => p.ColdStorage)
                    .FirstOrDefaultAsync(p => p.Id == position.Id);
                var response = _mapper.Map<PositionResponse>(savedPosition);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("cold-storage/{id}")]
        public async Task<ActionResult<ColdStorageResponse>> toggleactive(int id)
        {
            try
            {
                var coldStorage = await _context.ColdStorages
                    .FirstOrDefaultAsync(c => c.Id == id);

                coldStorage.Active = !coldStorage.Active;
                _context.ColdStorages.Update(coldStorage);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<ColdStorageResponse>(coldStorage);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
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

        [HttpPatch("pallet-position/{id}")]
        public async Task<ActionResult<PositionResponse>> removeposition(int id)
        {
            try
            {
                var position = await _context.PalletPositions
                    .FirstOrDefaultAsync(p => p.Id == id);

                position.Removed = true;
                _context.PalletPositions.Update(position);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<PositionResponse>(position);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("cold-storage/{id}")]
        public async Task<ActionResult> deletecs(int id)
        {
            try
            {
                var coldStorage = await _context.ColdStorages
                    .FirstOrDefaultAsync(c => c.Id == id);

                _context.ColdStorages.Remove(coldStorage);
                await _context.SaveChangesAsync();

                return Ok("Storage removed permanently.");
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

        [HttpDelete("pallet-position/{id}")]
        public async Task<ActionResult> deleteposition(int id)
        {
            try
            {
                var position = await _context.PalletPositions
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.PalletPositions.Remove(position);
                await _context.SaveChangesAsync();

                return Ok("Pallet position removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
