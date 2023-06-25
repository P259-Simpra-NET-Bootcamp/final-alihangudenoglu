using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtConfig _tokenOptions;


        public AuthManager(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptionsMonitor<JwtConfig> tokenOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenOptions = tokenOptions.CurrentValue;
        }

        public async Task<IDataResult<AccessToken>> SignIn(UserLoginDto userLoginDto)
        {
            if (userLoginDto is null)
            {
                return new ErrorDataResult<AccessToken>("Request was null");
            }
            if (string.IsNullOrEmpty(userLoginDto.UserName) || string.IsNullOrEmpty(userLoginDto.Password))
            {
                return new ErrorDataResult<AccessToken>("Request was null");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, true, false);
            if (!loginResult.Succeeded)
            {
                return new ErrorDataResult<AccessToken>("Invalid user");
            }

            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            var roles = (List<string>)_userManager.GetRolesAsync(user).Result;
            

            string token = Token(user, roles);
            AccessToken tokenResponse = new AccessToken
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration)
            };

            return new SuccessDataResult<AccessToken>(tokenResponse);
        }

        public async Task<IResult> SignOut()
        {
            var result= _signInManager.SignOutAsync();
            return new SuccessResult();
        }

        public async Task<IResult> ChangePassword(ClaimsPrincipal User, ChangePasswordDto changePasswordDto)
        {

            var user = await _userManager.GetUserAsync(User);
            var response = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.Password);
            if (!response.Succeeded)
            {
                return new ErrorResult("Change password error");
            }
            return new SuccessResult();
        }
        private string Token(User user, List<string> operationClaims)
        {
            IEnumerable<Claim> claims = GetClaims(user,operationClaims);
            var secret = Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey);

            var jwtToken = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claims:claims,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        private IEnumerable<Claim> GetClaims(User user, List<string> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c).ToArray());

            return claims;
        }
    }
}
