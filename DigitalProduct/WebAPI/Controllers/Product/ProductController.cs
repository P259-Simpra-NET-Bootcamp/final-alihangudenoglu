using Business.Abstract;
using DataAccess.Abstract.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryProductService _categoryProductDal;
        public ProductController(IProductService productService, ICategoryProductService categoryProductDal)
        {
            _productService = productService;
            _categoryProductDal = categoryProductDal;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var list = _productService.GetAll();
            return Ok(list);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return Ok(model);
        }
        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId(int id)
        {
            var model = _categoryProductDal.GetByCategoryList(id);
            return Ok(model);
        }

        [HttpPost("Add")]
        public IActionResult Add(ProductDto productDto)
        {
            var model = _productService.Add(productDto);
            return Ok(model);
        }
        [HttpPost("Update")]
        public IActionResult Update(ProductDto productDto)
        {
            var model = _productService.Update(productDto);
            return Ok(model);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var model = _productService.Delete(id);
            return Ok(model);
        }
    }
}
