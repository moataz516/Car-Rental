using CarRental.Models.Dtos;
using CarRental.Services.AccountUser;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountUser _account;
        public AccountController(IAccountUser account)
        {
                _account = account;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync (string id)
        {
            var userDetails = await _account.GetUserDetails(id);
            if (userDetails == null)
                return BadRequest();
            return Ok(userDetails);
        }



        [HttpPut("updateProfileImg/{id}")]
        public async Task<IActionResult> UpdateProfileImgAsync([FromForm] IFormFile fileImg,string id)
        {
            if (fileImg == null || fileImg.Length < 1)
            {
                return BadRequest();
            }
            var profileImgUpdated = await _account.UpdateUserProfileImg(fileImg,id);
            return Ok();
        }

        [HttpPatch("updateProfile")]
        public async Task<IActionResult>UpdateUserProfileAsync([FromBody]UserDto model)
        {
            var response = await _account.UpdateUserProfile(model);
            if (!response)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
