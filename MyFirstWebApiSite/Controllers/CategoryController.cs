using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]        
        public async Task<List<Category>> Get()
        {
           return await _categoryService.GetCategory();            
        }

    }
}
