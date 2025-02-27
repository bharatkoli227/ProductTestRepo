using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.DTO;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        [HttpPost]

        public IActionResult UploadImage([FromForm] ImageDTO image)
        {
            if(image == null)
            {
                return BadRequest();
                
            }

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.Image1.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();  // Convert the memory stream to byte array

                    // Convert byte array to Base64 string
                    string base64String = Convert.ToBase64String(fileBytes);

                    // Return the Base64 string as part of the response
                    return Ok(new { Base64String = base64String });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
