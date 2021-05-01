using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Core.Models;
using SuperMarket.Services;

namespace SuperMarket.Api.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController (IProductService productService){
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Get(){
            return Ok(_productService.GetProducts());
        }
        // public List<Product> Get(){
        //     return _productService.GetProducts();
        // }
        [HttpGet("{productId}")]
        public IActionResult Get (int productId){
            var product = _productService.GetProduct(productId);
            if (product == null){
                return NotFound();
            }
            return Ok(product);
        }
        // public Product Get (int productId){
        //     return _productService.GetProduct(productId);
        // }
        
        [HttpPost]
        public IActionResult Post ([FromBody] Product product){
            if (!ModelState.IsValid){
                return BadRequest ("Model is invalid!");
            }
            return Ok(_productService.AdddProduct(product));
        }
        // public Product Post([FromBody] Product product){
        //     return _productService.AdddProduct(product);
        // }
        [HttpPut("{productId}")]
        public Product Put (int productId, [FromBody] Product product){
            return _productService.EditProduct(productId, product);
        }
        [HttpDelete("{productId}")]
        public void Delete (int productId){
            _productService.DeleteProduct (productId);
        }
    }
}