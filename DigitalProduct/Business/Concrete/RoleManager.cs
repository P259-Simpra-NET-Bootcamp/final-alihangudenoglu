using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly RoleManager<Role> _roleIdentityManager;
        private readonly IMapper _mapper;
        public RoleManager(RoleManager<Role> roleIdentityManager, IMapper mapper)
        {
            _roleIdentityManager = roleIdentityManager;
            _mapper = mapper;
        }

        public async Task<IResult> Delete(int id)
        {
            var role = await _roleIdentityManager.FindByIdAsync(id.ToString());
            await _roleIdentityManager.DeleteAsync(role);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<RoleDto>>> GetAll()
        {
            var role = _roleIdentityManager.Roles.ToList();
            var mapped=_mapper.Map<List<Role>,List<RoleDto>>(role);
            return new SuccessDataResult<List<RoleDto>>(mapped);
        }

        public async Task<IDataResult<RoleDto>> GetById(int id)
        {
            var role = _roleIdentityManager.Roles.Where(x=>x.Id==id).FirstOrDefault();
            var mapped = _mapper.Map<Role, RoleDto>(role);
            return new SuccessDataResult<RoleDto>(mapped);
        }

        public async Task<IResult> Insert(RoleDto role)
        {
            var mapped = _mapper.Map<RoleDto, Role>(role);
            await _roleIdentityManager.CreateAsync(mapped);
            return new SuccessResult();
        }
    }
}
