using CarRental.Models.AccountDto;
using CarRental.Models.Data;
using CarRental.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _auth;

        public AuthController( IAuthentication auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthDto>> Register([FromBody] SignUpDto model)
        {
            /* if (!ModelState.IsValid)
            {
                var firstErrorMessage = ModelState.Values.FirstOrDefault(v => v.Errors.Any())?.Errors.FirstOrDefault()?.ErrorMessage;
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest("AsdasD");
            }
            */

            var registerUser = await _auth.Register(model);
            if (registerUser.IsAuthenticated == true)
            {
                return Ok(registerUser) ;
            }
            return BadRequest(registerUser.Message);
        }


        [HttpPost("login")]

        public async Task<ActionResult<AuthDto>> Login(SignInDto model)
        {
            var loginUser = await _auth.Login(model);
            if(loginUser.IsAuthenticated == true) 
            {
                return Ok(loginUser);
            }
            return BadRequest(loginUser.Message );
        }


    }
}
