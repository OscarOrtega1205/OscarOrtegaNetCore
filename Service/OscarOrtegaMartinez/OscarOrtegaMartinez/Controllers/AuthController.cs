using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OscarOrtegaMartinez.Models.Request;
using OscarOrtegaMartinez.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OscarOrtegaMartinez.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, ActionName("Login")]
        public IActionResult Authentification([FromBody] AuthRequest authRequest)
        {
            var response = _userService.Auth(authRequest);
            
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
