using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IBasketService _basketService;
        private IWalletService _walletService;
        public UserController(IUserService userService, IBasketService basketService, IWalletService walletService)
        {
            _userService = userService;
            _basketService = basketService;
            _walletService = walletService;
        }

        [HttpGet("GetAll")]
        public async Task<IDataResult<List<UserGetDto>>> GetAll()
        {
            var list = await _userService.GetAll();
            return list;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var model = _userService.GetById(id);
            return Ok(model.Result);
        }
        [HttpGet("GetUserId")]
        public IActionResult GetUserId()
        {
            var model = _userService.GetUserId(HttpContext.User);
            return Ok(model.Result);
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            var model = _userService.GetUser(HttpContext.User);
            return Ok(model.Result);
        }

        [HttpPost("AddUser")]
        public IActionResult Add(UserRegisterDto user)
        {
            var model = _userService.AddUser(user);
            _basketService.Add(model.Result.Data);
            _walletService.Add(model.Result.Data);
            return Ok();
        }
        
        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin(UserRegisterDto user)
        {
            var model = _userService.AddAdmin(user);
            return Ok(model.Result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var model = _userService.Delete(id);
            return Ok(model.Result);
        }
        [HttpPut("Update")]
        public IActionResult Update(UserRegisterDto user)
        {
            var model = _userService.Update(user);
            return Ok(model.Result);
        }
    }
}
