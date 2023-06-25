using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<IDataResult<UserGetDto>> GetUser(ClaimsPrincipal User);
        public Task<IDataResult<int>> AddUser(UserRegisterDto user);
        public Task<IResult> AddAdmin(UserRegisterDto user);
        public Task<IResult> Update(UserRegisterDto user);
        public Task<IResult> Delete(int id);
        public Task<IDataResult<List<UserGetDto>>> GetAll();
        public Task<IDataResult<UserGetDto>> GetById(int id);
        public Task<IDataResult<int>> GetUserId(ClaimsPrincipal User);
    }
}
