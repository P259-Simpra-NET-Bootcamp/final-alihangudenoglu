using Business.Abstract;
using Entities.DTOs.BasketItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebAPI.Controllers.Basket
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("AddProducts")]
        public IActionResult AddProducts(List<BasketItemDto> basketItems)
        {
            var model = _basketService.AddItem(HttpContext.User,basketItems);
            return Ok(model);
        }
        [HttpPost("UpdateProducts")]
        public IActionResult UpdateProducts(List<BasketItemDto> basketItems)
        {
            var model = _basketService.UpdateItem(HttpContext.User, basketItems);
            return Ok(model);
        }
        [HttpPost("DeleteProducts")]
        public IActionResult DeleteProducts(List<BasketItemDto> basketItems)
        {
            var model = _basketService.DeleteItem(HttpContext.User, basketItems);
            return Ok(model);
        }
        [HttpGet("GetBasket")]
        public IActionResult GetBasket()
        {
            var model = _basketService.GetByUserId(HttpContext.User);
            return Ok(model.Result.Data);
        }


    }
}
