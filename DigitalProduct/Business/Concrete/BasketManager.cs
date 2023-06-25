using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.BasketItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketDal _basketDal;
        private IUserService _userService;
        private IBasketItemService _basketItemService;

        public BasketManager(IUserService userService, IBasketDal basketDal, IBasketItemService basketItemService)
        {
            _userService = userService;
            _basketDal = basketDal;
            _basketItemService = basketItemService;
        }

        public IResult Add(int userId)
        {
            Basket basket = new Basket();
            basket.UserId = userId;
            basket.TotalPrice = 0;
            _basketDal.Insert(basket);
            _basketDal.Complete();
            return new SuccessResult();
        }

        public async Task<IResult> AddItem(ClaimsPrincipal claimsPrincipal, List<BasketItemDto> basketItems)
        {
            var user=await _userService.GetUserId(claimsPrincipal);
            var basket = _basketDal.Where(x => x.UserId == user.Data).FirstOrDefault();
            var result = _basketItemService.Add(basketItems, basket.Id);
            if (!result.Success)
            {

            }
            basket.TotalPrice = result.Data;
            _basketDal.Update(basket);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteItem(ClaimsPrincipal claimsPrincipal, List<BasketItemDto> basketItems)
        {
            var user = await _userService.GetUserId(claimsPrincipal);
            var basket = _basketDal.Where(x => x.UserId == user.Data).FirstOrDefault();
            var result = _basketItemService.Delete(basketItems, basket.Id);
            if (!result.Success)
            {

            }
            basket.TotalPrice = result.Data;
            _basketDal.Update(basket);
            return new SuccessResult();
        }

        public async Task<IDataResult<Basket>>  GetByUserId(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userService.GetUserId(claimsPrincipal);
            var basket = _basketDal.WhereWithInclude(x=>x.UserId==user.Data,"BasketItems").FirstOrDefault();
            
            return new SuccessDataResult<Basket>(basket);
        }

        public async Task<IResult> UpdateItem(ClaimsPrincipal claimsPrincipal, List<BasketItemDto> basketItems)
        {
            var user = await _userService.GetUserId(claimsPrincipal);
            var basket = _basketDal.Where(x => x.UserId == user.Data).FirstOrDefault();
            var result = _basketItemService.Delete(basketItems, basket.Id);
            if (!result.Success)
            {

            }
            basket.TotalPrice = result.Data;
            _basketDal.Update(basket);
            return new SuccessResult();
        }
    }
}
