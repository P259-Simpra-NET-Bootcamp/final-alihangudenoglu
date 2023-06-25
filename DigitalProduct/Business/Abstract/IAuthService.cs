using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> SignIn(UserLoginDto userLoginDto);
        public Task<IResult> SignOut();
        public Task<IResult> ChangePassword(ClaimsPrincipal User, ChangePasswordDto changePasswordDto);
    }
}
