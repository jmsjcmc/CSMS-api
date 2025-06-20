﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Csms_api.Helpers
{
    [Route("")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public BaseApiController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected ActionResult handleexception(Exception e)
        {
            return new ObjectResult(e.InnerException?.Message ?? e.Message)
            {
                StatusCode = 500
            };
        }
    }
}
