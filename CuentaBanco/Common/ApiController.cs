using CuentaBanco.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaBanco.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected IActionResult GetStatus(int status, Response response)
        {
            switch (status)
            {
                case 200:
                    return Ok(response);
                case 201:
                    return Ok(response);
                case 202:
                    return Accepted(response);
                case 400:
                    return BadRequest(response);
                case 404:
                    return NotFound(response);
                case 500:
                    return Problem(response.Message);
                default:
                    return StatusCode(response.Status, response);
            }
        }
    }
}
