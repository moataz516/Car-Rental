using CarRental.Models.Dtos;
using CarRental.Services.PublicSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IPublicService _publicService;

        public ContactUsController(IPublicService publicService)
        {
                _publicService = publicService;
        }

        // GET: api/<ContactUsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        public async Task<ActionResult> PostUserMessage([FromBody]ContactDto model)
        {
            bool data = await _publicService.PostUserMessageAsync(model);
            if (!data)
            {
                return BadRequest("Error");
            }
            return Ok();
        }
        
        


    }
}
