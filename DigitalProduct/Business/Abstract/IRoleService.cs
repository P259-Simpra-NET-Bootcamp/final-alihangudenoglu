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
    public interface IRoleService
    {        
        public Task<IResult> Insert(RoleDto role);
        public Task<IResult> Delete(int id);
        public Task<IDataResult<List<RoleDto>>> GetAll();
        public Task<IDataResult<RoleDto>> GetById(int id);
    }
}
