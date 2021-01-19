using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Repositories.Filters;

namespace TCYDMWebServices.Controllers.V1
{
    [Validator]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("/test")]
        public IActionResult Test([FromBody] UserDTO request)
        {
            return Ok(request);
        }
    }
}
