using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTO;
using ProductBAL.ProductBAL;
using ProductModel.Model;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBAL productbl;
        private readonly IHostEnvironment hosting;

        public ProductsController(IProductBAL productbl, IHostEnvironment hosting)
        {
            this.productbl = productbl;
            this.hosting = hosting;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm]ProductDTO product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Please Enter Valid Product Details");
                }
                var filepath1 = "";
                if (product.Image1 != null && product.Image1.Length > 0)
                {
                    filepath1 = UploadMultiPartFile(product.Image1);
                }

                //var response = productbl.CreateProduct(product);
                var filepath2 = "";

                if (!String.IsNullOrEmpty(product.Image2))
                {
                    filepath2 = UploadBaseCodeFile(product.Image2);
                }

                Product product1 = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Image1 = filepath1,
                    Image2 = filepath2
                };

                var response = productbl.CreateProduct(product1);
                if (response)
                {
                    return Ok("Product Created Succesfully");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception e)
            {
                return StatusCode(500,e.Message);
            }
            

        }

        private string UploadBaseCodeFile(string image2)
        {
            //throw new NotImplementedException();
            var base64Data1 = image2.Split(',');
            var base64Data = (base64Data1.Count() > 1) ? base64Data1[1] : base64Data1[0];


            var imageBytes = Convert.FromBase64String(base64Data);

            var ImagesFolder = Path.Combine(hosting.ContentRootPath, "Images");
            if(!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }

            var FileName = Guid.NewGuid().ToString() + ".jpg";
            var FilePath = Path.Combine(ImagesFolder, FileName);    

            System.IO.File.WriteAllBytes(FilePath, imageBytes);
            var fileurl = $"{Request.Scheme}://{Request.Host}/Images/{FileName}";
            return fileurl;
        }

        private string UploadMultiPartFile(IFormFile Image1)
        {
            var ImagesFolder = Path.Combine(hosting.ContentRootPath, "Images");
            if(!Directory.Exists("ImagesFolder"))
            {
                Directory.CreateDirectory("ImagesFolder");
            }

            var FileName = Guid.NewGuid().ToString() + Path.GetExtension(Image1.FileName);
            var FilePath = Path.Combine(ImagesFolder, FileName);

            using (var stream = new FileStream(FilePath,FileMode.Create))
            {
                stream.CopyTo(stream);
            }

            var fileUrl = $"{Request.Scheme}://{Request.Host}/Images/{FileName}";
            return fileUrl;

        }
    }
}
