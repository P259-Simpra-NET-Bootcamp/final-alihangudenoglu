using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private  ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var list = _categoryService.GetAll();
            return Ok(list);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var model = _categoryService.GetById(id);
            return Ok(model);
        }

        [HttpPost("Add")]
        public IActionResult Add(CategoryDto category)
        {
            var model = _categoryService.Add(category);
            return Ok(model);
        }
        [HttpPost("Update")]
        public IActionResult Update(CategoryDto category)
        {
            var model = _categoryService.Update(category);
            return Ok(model);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var model = _categoryService.Delete(id);
            return Ok(model);
        }
    }
}
