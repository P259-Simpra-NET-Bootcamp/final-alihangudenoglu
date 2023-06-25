using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.BasketItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBasketItemService
    {
        
        public IDataResult<decimal> Add( List<BasketItemDto> basketItems,int basketId);
        public IDataResult<decimal> Update( List<BasketItemDto> basketItems, int basketId);
        public IDataResult<decimal> Delete( List<BasketItemDto> basketItems, int basketId);
    }
}
