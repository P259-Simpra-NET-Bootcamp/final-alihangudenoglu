using Business.Abstract;
using Entities.DTOs.Discount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Discount
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var list = _discountService.GetAll();
            return Ok(list);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var model = _discountService.GetById(id);
            return Ok(model);
        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int id)
        {
            var model = _discountService.GetByUserId(id);
            return Ok(model);
        }

        [HttpPost("Add")]
        public IActionResult Add(DiscountDto discountDto)
        {
            var model = _discountService.Add(discountDto);
            return Ok(model);
        }
        [HttpPost("Update")]
        public IActionResult Update(DiscountDto discountDto)
        {
            var model = _discountService.Update(discountDto);
            return Ok(model);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var model = _discountService.Delete(id);
            return Ok(model);
        }
    }
}
