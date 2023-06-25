using Autofac.Core;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var list = _roleService.GetAll();
            return Ok(list.Result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var model = _roleService.GetById(id);
            return Ok(model.Result);
        }

        [HttpPost("Add")]
        public IActionResult Add(RoleDto role)
        {
            var model = _roleService.Insert(role);
            return Ok(model.Result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var model = _roleService.Delete(id);
            return Ok(model.Result);
        }
    }
}
