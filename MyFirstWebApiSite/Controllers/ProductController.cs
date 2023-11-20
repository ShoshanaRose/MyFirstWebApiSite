using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller       
    {
        IProductService _ProductService;
        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }

        // GET: ProductController   
        [HttpGet]
        public async Task<IEnumerable<Product>> Get(string? name, int? minPrice, int? maxPrice, [FromQuery]int?[] categoryIds)
        {
            return await _ProductService.getAllProducts(name, minPrice, maxPrice, categoryIds);
        }
        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await _ProductService.getAllProducts();
        //}
    }   
}
