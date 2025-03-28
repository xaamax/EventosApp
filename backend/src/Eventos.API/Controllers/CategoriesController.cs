using AutoMapper;
using Eventos.Application.Dtos.Category;
using Eventos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorys()
        {
            var response = await _categoryService.GetAllCategorys();
            return Ok(response);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryById(id);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddCategory(CategoryAddOrEditDTO dto)
        {
            var response = await _categoryService.AddCategory(dto);
            return Created("", response); ;
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryAddOrEditDTO dto)
        {
            var response = await _categoryService.UpdateCategory(id, dto);
            return Ok(response);
        }

        [HttpPatch("{id}/delete")]
        public async Task<IActionResult> DeleteCategory(int id, CategoryDeleteDTO dto)
        {
            var response = await _categoryService.DeleteCategory(id, dto);
            return Ok(response);
        }
    }
}
