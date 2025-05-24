using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Helpers;
using Csms_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Csms_api.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly AuthHelper _authHelper;

        public UserController(AppDbContext context, IConfiguration configuration, IMapper mapper, AuthHelper authHelper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _authHelper = authHelper;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserResponse>> getuser(int id)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.BusinessUnit)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id);

                var response = _mapper.Map<UserResponse>(user);
                return response;

            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("users")]
        public async Task<ActionResult<Paginate<UserResponse>>> allusers(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var query = _context.Users
                    .AsNoTracking()
                    .Include(u => u.BusinessUnit)
                    .OrderByDescending(u => u.Created_on)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(u => u.Last_name == searchTerm);
                }

                var totalCount = await query.CountAsync();
                var users = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<UserResponse>
                {
                    Items = users,
                    Total_count = totalCount,
                    Page_number = pageNumber,
                    Page_size = pageSize
                };

                return response;

            }catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("user-detail")]
        public async Task<ActionResult<UserResponse>> authuserdetail()
        {
            try
            {
                var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                int id = int.Parse(idClaim.Value);
                var user = await _context.Users
                    .AsNoTracking()
                    .Include(u => u.BusinessUnit)
                    .FirstOrDefaultAsync(u => u.Id == id);

                var userDetail = _mapper.Map<UserResponse>(user);
                return userDetail;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("business-unit/{id}")]
        public async Task<ActionResult<BusinessUnitResponse>> getbusinessunit(int id)
        {
            try
            {
                var businessUnit = await _context.BusinessUnits
                    .FindAsync(id);

                var response = _mapper.Map<BusinessUnitResponse>(businessUnit);
                return response;

            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("business-units")]
        public async Task<ActionResult<Paginate<BusinessUnitResponse>>> allbusinessunits(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null)
        {
            try
            {
                var query = _context.BusinessUnits
                    .AsNoTracking()
                    .OrderByDescending(b => b.Business_unit)
                    .AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(b => b.Business_unit == searchTerm);
                }

                var totalCount = await  query.CountAsync();

                var businessUnits = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<BusinessUnitResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var response = new Paginate<BusinessUnitResponse>
                {
                    Items = businessUnits,
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

        [HttpGet("role/{id}")]
        public async Task<ActionResult<Role>> getrole(int id)
        {
            try
            {
                var role = await _context.Roles
                    .FindAsync(id);

                var response = _mapper.Map<Role>(role);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<Role>>> allroles()
        {
            try
            {
                var roles = await _context.Roles
                    .AsNoTracking()
                    .ToListAsync();

                return roles;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> login(string username, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);

                var accessToken = _authHelper.GenerateAccessToken(user);

                await _context.SaveChangesAsync();

                return Ok(
                    new
                    {
                        AccessToken = accessToken,
                        User = new
                        {
                            user.Id,
                            user.Username,
                            user.Role
                        }
                    });
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("user")]
        public async Task<ActionResult<UserResponse>> adduser([FromBody] UserRequest request)
        {
            try
            {
                var requestRoles = request.Roles
                    .Select(r => r.Trim())
                    .ToList();

                var existingRoles = await _context.Roles
                    .Where(r => requestRoles.Contains(r.Role_name))
                    .ToListAsync();

                var roleNames = string.Join(", ", existingRoles.Select(r => r.Role_name).OrderBy(r => r));

                var user = _mapper.Map<User>(request);
                user.Role = roleNames;
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.Created_on = TimeHelper.GetPhilippineTime();
                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                var response = _mapper.Map<UserResponse>(user);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("user/{id}")]
        public async Task<ActionResult> hideuser(int id)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                user.Removed = true;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return Ok("User removed.");

            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("user/{id}")]
        public async Task<ActionResult> deleteuser(int id)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok("User removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("role")]
        public async Task<ActionResult<Role>> addrole(string roleName)
        {
            try
            {
                var role = new Role
                {
                    Role_name = roleName
                };

                _context.Roles.Add(role);

                await _context.SaveChangesAsync();

                return role;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("role/{id}")]
        public async Task<ActionResult> hiderole(int id)
        {
            try
            {
                var role = await _context.Roles
                    .FirstOrDefaultAsync(r => r.Id == id);

                role.Removed = true;

                _context.Roles.Update(role);
                await _context.SaveChangesAsync();

                return Ok("Role removed.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("role/{id}")]
        public async Task<ActionResult> deleterole(int id)
        {
            try
            {
                var role = await _context.Roles
                    .FirstOrDefaultAsync(r => r.Id == id);

                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();

                return Ok("Role removed permanently.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("business-unit")]
        public async Task<ActionResult<BusinessUnitResponse>> addbusinessunit([FromBody] BusinessUnitRequest request)
        {
            try
            {
                var businessUnit = _mapper.Map<BusinessUnit>(request);
                _context.BusinessUnits.Add(businessUnit);

                await _context.SaveChangesAsync();

                var response = _mapper.Map<BusinessUnitResponse>(businessUnit);
                return response;
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPatch("business-unit/{id}")]
        public async Task<ActionResult> hidebusinessunit(int id)
        {
            try
            {
                var businessUnit = await _context.BusinessUnits
                    .FirstOrDefaultAsync(b => b.Id == id);

                businessUnit.Removed = true;

                _context.BusinessUnits.Update(businessUnit);
                await _context.SaveChangesAsync();
                return Ok("Business unit removed.");
            } catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("business-unit/{id}")]
        public async Task<ActionResult>deletebusinessunit(int id)
        {
            try
            {
                var businessUnit = await _context.BusinessUnits
                    .FirstOrDefaultAsync(b => b.Id == id);

                _context.BusinessUnits.Remove(businessUnit);
                await _context.SaveChangesAsync();

                return Ok("Business unit removed permanently.");
            }catch (Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
