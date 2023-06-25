using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var list = await _service.SignIn(userLoginDto);
            return Ok(list);
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            var model =await _service.SignOut();
            return Ok(model);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var model =await _service.ChangePassword(HttpContext.User, changePasswordDto);
            return Ok(model);
        }
    }
}
