using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Wallet;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WalletManager : IWalletService
    {
        private UserManager<User> _userIdentityManager;
        private IWalletDal _walletDal;
        private readonly IMapper _mapper;
        public WalletManager(IWalletDal walletDal, IMapper mapper, UserManager<User> userIdentityManager, IBasketService basketService)
        {
            _walletDal = walletDal;
            _mapper = mapper;
            _userIdentityManager = userIdentityManager;

        }
        public IResult Add(int userId)
        {
            Wallet wallet = new Wallet();
            wallet.UserId = userId;
            wallet.Balance = 0;
            _walletDal.Insert(wallet);
            _walletDal.Complete();
            return new SuccessResult();
        }

        public IResult AddBalance(int userId, decimal balance)
        {
            var entity=_walletDal.GetById(userId);
            entity.Balance += balance;
            _walletDal.Update(entity);
            _walletDal.Complete();
            return new SuccessResult();
        }

        public IDataResult<WalletDto> GetByUserId(int userId)
        {
            var entity = _walletDal.GetById(userId);
            var result=_mapper.Map<Wallet, WalletDto>(entity);
            return new SuccessDataResult<WalletDto>(result);
        }

        public IResult ReduceBalance(int userId, decimal balance)
        {
            var entity = _walletDal.GetById(userId);
            entity.Balance -=balance;
            _walletDal.Update(entity);
            _walletDal.Complete();
            return new SuccessResult();
        }

        public async Task<IDataResult<WalletDto>> GetBalance(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userIdentityManager.GetUserAsync(claimsPrincipal);
            var result=_walletDal.Where(x=>x.UserId == user.Id).SingleOrDefault();
            var mapped = _mapper.Map<Wallet, WalletDto>(result);
            return new SuccessDataResult<WalletDto>(mapped);
        }
    }
}
