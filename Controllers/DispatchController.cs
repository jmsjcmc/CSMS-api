
using AutoMapper;
using Csms_api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Csms_api.Controllers
{
    public class DispatchController : BaseApiController
    {
        public DispatchController(AppDbContext context, IMapper mapper) : base (context, mapper)
        {
        }
    }
}
