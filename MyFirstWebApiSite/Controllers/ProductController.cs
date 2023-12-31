using AutoMapper;
using DTO;
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
        IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _ProductService = productService;
            _mapper = mapper;
        }

        // GET: ProductController   
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(string? name, int? minPrice, int? maxPrice, [FromQuery]int?[] categoryIds)
        {
            List<Product> products = await _ProductService.getAllProductsAsync(name, minPrice, maxPrice, categoryIds);
            List<productDTO> productsDTO = _mapper.Map<List<Product>, List<productDTO>>(products);
            return Ok(productsDTO);
        }
    }   
}
