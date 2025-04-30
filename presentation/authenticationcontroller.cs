using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using services.abstractions;
using shared.identitydtos;

namespace presentation.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Iservicemanagment _servicemanagment;

        public AuthenticationController(Iservicemanagment servicemanagment)
        {
            _servicemanagment = servicemanagment;
        }

       

        [HttpPost("login")]
        public async Task<ActionResult<userresultdto>> Login([FromBody] logindto logindto)
        {
            var result = await _servicemanagment.authenticationservice.login(logindto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<userresultdto>> Register([FromBody] registerdto registerdto)
        {
            var result = await _servicemanagment.authenticationservice.register(registerdto);
            return Ok(result);
        }
    }
}