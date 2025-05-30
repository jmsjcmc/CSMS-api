using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csms_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DispatchController(AppDbContext context)
        {
            _context = context;
        }
    }
}
