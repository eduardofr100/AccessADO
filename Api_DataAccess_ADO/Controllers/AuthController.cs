using Api_DataAccess_ADO.Helpers;
using Api_DataAccess_ADO.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api_DataAccess_ADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials creds)
        {
            if (creds.Username == "admin" && creds.Password == "1234")
            {
                var token = JwtHelper.GenerateJwt(creds.Username, _config);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
