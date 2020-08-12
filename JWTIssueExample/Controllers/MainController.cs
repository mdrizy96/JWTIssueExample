using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTIssueExample.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace JWTIssueExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationManager _authManager;

        public MainController(IConfiguration configuration, IAuthenticationManager authManager)
        {
            _configuration = configuration;
            _authManager = authManager;
        }

        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken()
        {
            return Ok(new { Token = await _authManager.CreateToken() });
        }

        [HttpPost("getname1")]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity is ClaimsIdentity identity)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

        [Authorize]
        [HttpPost("getname2")]
        public Object GetName2()
        {
            if (User.Identity is ClaimsIdentity identity)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.FirstOrDefault(p => p.Type == "name")?.Value;
                return new
                {
                    data = name
                };

            }
            return null;
        }
    }

}