using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userIdentityManager;
        private readonly IMapper _mapper;


        public UserManager(UserManager<User> userIdentityManager, IMapper mapper)
        {
            _userIdentityManager = userIdentityManager;
            _mapper = mapper;
        }
        public async Task<IResult> Delete(int id)
        {
            if (id==null||id<1)
            {
                return new ErrorResult();
            }

            var user = _userIdentityManager.Users.Where(x => x.Id == id).FirstOrDefault();
            await _userIdentityManager.DeleteAsync(user);

            return new SuccessResult();
        }
        
        public async Task<IDataResult<List<UserGetDto>>> GetAll()
        {
            
            var list = _userIdentityManager.Users.ToList();
            var mapped = _mapper.Map<List<User>,List<UserGetDto>>(list);
            return new SuccessDataResult<List<UserGetDto>> (mapped);
        }

        public async Task<IDataResult<UserGetDto>> GetById(int id)
        {
            
            var list = _userIdentityManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var mapped = _mapper.Map<User,UserGetDto>(list);
            return new SuccessDataResult<UserGetDto>(mapped);
        }

        public async Task<IDataResult<UserGetDto>> GetUser(ClaimsPrincipal User)
        {
            var user = await _userIdentityManager.GetUserAsync(User);
            if (user == null)
            {
                return new ErrorDataResult<UserGetDto>("geçersiz token");
            }
            var mapped = _mapper.Map<User,UserGetDto>(user);
            return new SuccessDataResult<UserGetDto>(mapped);
        }

        public async Task<IDataResult<int>> GetUserId(ClaimsPrincipal User)
        {
            var id = _userIdentityManager.GetUserId(User);
            if (string.IsNullOrEmpty(id))
            {
                return new ErrorDataResult<int>("geçersiz token");
            }
            return new SuccessDataResult<int>(int.Parse(id));
        }

        
        public async Task<IDataResult<int>> AddUser(UserRegisterDto user)
        {

            var entity = _mapper.Map<UserRegisterDto,User> (user);
            entity.EmailConfirmed = true;
            entity.TwoFactorEnabled = false;

            var response = await _userIdentityManager.CreateAsync(entity,user.Password);
            if (!response.Succeeded)
            {
                return new SuccessDataResult<int>(response.Errors.FirstOrDefault()?.Description);
            }
            await _userIdentityManager.AddToRoleAsync(entity, "User");
            return new SuccessDataResult<int>(entity.Id);
        }
        //[SecuredOperation("Admin")]
        public async Task<IResult> AddAdmin(UserRegisterDto user)
        {

            var entity = _mapper.Map<UserRegisterDto, User>(user);
            entity.EmailConfirmed = true;
            entity.TwoFactorEnabled = false;

            var response = await _userIdentityManager.CreateAsync(entity, user.Password);

            if (!response.Succeeded)
            {
                return new ErrorResult(response.Errors.FirstOrDefault()?.Description);
            }
            await _userIdentityManager.AddToRoleAsync(entity, "Admin");
            return new SuccessResult();
        }

        public async Task<IResult> Update(UserRegisterDto user)
        {

            
            var result= _userIdentityManager.Users.Where(x=>x.Email==user.Email).FirstOrDefault();
            var entity = _mapper.Map<UserRegisterDto,User>(user,result);
            await _userIdentityManager.UpdateAsync(entity);

            return new SuccessResult();
        }
    }
}
