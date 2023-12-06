using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        ICategoryService _categoryService;
        IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]        
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await _categoryService.GetCategory();
            List<categoryDTO> categoryDTOs = _mapper.Map<List<Category>, List<categoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

    }
}
