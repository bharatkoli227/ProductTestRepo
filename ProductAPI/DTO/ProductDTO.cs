using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ProductAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter the product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter the product Description")]
        public string Description { get; set; }

        [Range(minimum:1,maximum: 10000,ErrorMessage ="Please Enter Valid Price")]
        public int Price { get; set; }
        public IFormFile Image1 { get; set; }        
        public string Image2 { get; set; }
    }
}
