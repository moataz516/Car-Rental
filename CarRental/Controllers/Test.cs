using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        private readonly string filePathUrl = @"P:\Angular and .Net\CarRental\wwwroot\Images\test";



        [HttpPost]
        public async Task<IActionResult> FileTest([FromForm] List<IFormFile> files)
        {

            //var size = files.Sum(fn => fn.Length);
            if (!Directory.Exists(filePathUrl))
            {
                Directory.CreateDirectory(filePathUrl);
            }
            

                foreach (var file in files)
                {            
                    if(file.Length > 0)
                    {
                        string name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var filePath  = Path.Combine(filePathUrl,  name);
                        
                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                    }
            }
            return Ok();

        }


    }


    public class AppFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
}
