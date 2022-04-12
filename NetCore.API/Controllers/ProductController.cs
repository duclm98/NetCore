using Microsoft.AspNetCore.Mvc;
using NetCore.API.Dto.Product;
using NetCore.API.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace NetCore.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [SwaggerOperation(Summary = "Danh sách sản phẩm")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _productService.GetAll();
        }

        [SwaggerOperation(Summary = "Chi tiết sản phẩm")]
        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetSingle(int productId)
        {
            return await _productService.GetSingle(productId);
        }

        [SwaggerOperation(Summary = "Thêm sản phẩm")]
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] ProductCreateDto productCreateDto)
        {
            return await _productService.Add(productCreateDto);
        }

        [SwaggerOperation(Summary = "Chỉnh sửa sản phẩm")]
        [HttpPut("{productId:int}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductUpdateDto productUpdateDto)
        {
            return await _productService.Update(productId, productUpdateDto);
        }

        [SwaggerOperation(Summary = "Xóa sản phẩm")]
        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> Delete(int productId)
        {
            return await _productService.Delete(productId);
        }
    }
}