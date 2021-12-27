using System.ComponentModel.DataAnnotations;

namespace NetCore.API.Dto.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}