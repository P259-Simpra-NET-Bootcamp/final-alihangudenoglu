using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.BasketItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BasketItemManager : IBasketItemService
    {
        private IBasketItemDal _basketItemDal;
        private readonly IMapper _mapper;

        public BasketItemManager(IBasketItemDal basketItemDal, IMapper mapper)
        {
            _basketItemDal = basketItemDal;
            _mapper = mapper;
        }

        public IDataResult<decimal> Add(List<BasketItemDto> basketItems, int basketId)
        {
            var mapped = _mapper.Map<List<BasketItemDto>, List<BasketItem>>(basketItems);
            foreach (var item in mapped)
            {
                item.BasketId = basketId;
            }
            _basketItemDal.InsertRange(mapped);
            _basketItemDal.Complete();
            return new SuccessDataResult<decimal>(CalculateProductPrice(basketId));
        }

        public IDataResult<decimal> Delete(List<BasketItemDto> basketItems, int basketId)
        {
            var mapped = _mapper.Map<List<BasketItemDto>, List<BasketItem>>(basketItems);
            foreach (var item in mapped)
            {
                item.BasketId = basketId;
                _basketItemDal.DeleteById(item.Id);
            }
            _basketItemDal.Complete();
            return new SuccessDataResult<decimal>(CalculateProductPrice(basketId));
        }

        public IDataResult<decimal> Update(List<BasketItemDto> basketItems, int basketId)
        {
            var mapped = _mapper.Map<List<BasketItemDto>, List<BasketItem>>(basketItems);
            foreach (var item in mapped)
            {
                item.BasketId = basketId;
                _basketItemDal.Update(item);
            }
            _basketItemDal.Complete();

            return new SuccessDataResult<decimal>(CalculateProductPrice(basketId));
        }
        
        public decimal CalculateProductPrice(int basketId)
        {
            var result = _basketItemDal.Where(x=>x.BasketId==basketId);
            decimal totalPrice=0;
            foreach (var item in result)
            {
                var entity=_basketItemDal.GetByIdWithInclude(item.Id,"Products");
                totalPrice += entity.Product.Price;

            }
            return totalPrice;
        }
    }
}
