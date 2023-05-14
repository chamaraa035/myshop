using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopCore.Web.API.Models.Products;
using MyShopCore.Web.API.Services.Foundations.Products;

namespace MyShopCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts() 
        {
            var products=this.productService.RetrieveAllProducts();
            return Ok(products);    
        }

        [HttpGet("id",Name ="GetSingleProduct")]
        public async ValueTask<IActionResult> GetProductAsync(Guid id)
        {
            var product = await this.productService.RetreiveProductBIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostProduct([FromBody]Product product) 
        {
          var newProduct=await this.productService.AddProductAsync(product);
          return Created("GetSingleProduct", newProduct);
        
        }
        [HttpPut]
        public async ValueTask<IActionResult> PutProduct([FromBody] Product product) 
        {
            var currentProduct = await this.productService.RetreiveProductBIdAsync(product.Id);

            if (currentProduct is null)
            {
                return NotFound();
            }

            var updateProduct=await this.productService.ModifiedProductAsync(product);

            return Ok(updateProduct);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteProduct(Guid id) 
        {
            var currentproduct = await this.productService.RetreiveProductBIdAsync(id);

            if (currentproduct is null)
            {
                return NotFound();
            }

            var deleteProduct= this.productService.RemoveProductAsync(currentproduct);
            return NoContent();
        }
    }
}
