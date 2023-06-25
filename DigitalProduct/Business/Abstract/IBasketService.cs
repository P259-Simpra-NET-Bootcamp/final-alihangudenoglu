using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.BasketItem;
using Entities.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketService
    {
        public IResult Add(int userId);
        public Task<IResult> AddItem(ClaimsPrincipal claimsPrincipal,List<BasketItemDto> basketItems);
        public Task<IResult> UpdateItem(ClaimsPrincipal claimsPrincipal,List<BasketItemDto> basketItems);
        public Task<IResult> DeleteItem(ClaimsPrincipal claimsPrincipal,List<BasketItemDto> basketItems);
        public Task<IDataResult<Basket>> GetByUserId(ClaimsPrincipal claimsPrincipal);
    }
}
