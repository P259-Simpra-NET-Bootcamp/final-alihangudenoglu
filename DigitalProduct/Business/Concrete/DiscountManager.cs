using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Entities.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private IDiscountDal _discountDal;
        private readonly IMapper _mapper;
        public DiscountManager(IDiscountDal discountDal,IMapper mapper)
        {
            _discountDal = discountDal;
            _mapper = mapper;
        }
        public IResult Add(DiscountDto discountDto)
        {
            var entity = _mapper.Map<DiscountDto, Discount>(discountDto);
            entity.Code=Guid.NewGuid().ToString("N").Substring(0,9);
            _discountDal.Insert(entity);
            _discountDal.Complete();
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            
            _discountDal.DeleteById(id);
            _discountDal.Complete();
            return new SuccessResult();
        }

        public IDataResult<List<DiscountDto>> GetAll()
        {
            var result=_discountDal.GetAll();
            var entity = _mapper.Map<List<Discount>, List<DiscountDto>>(result);

            return new SuccessDataResult<List<DiscountDto>>(entity);
        }

        public IDataResult<DiscountDto> GetById(int id)
        {
            var result = _discountDal.GetById(id);
            var entity = _mapper.Map<Discount,DiscountDto>(result);
            return new SuccessDataResult<DiscountDto>(entity);
        }
        public IDataResult<List<DiscountDto>> GetByUserId(int id)
        {
            var result = _discountDal.Where(x=>x.UserId==id).ToList();
            var entity = _mapper.Map<List<Discount>, List<DiscountDto>>(result);
            return new SuccessDataResult<List<DiscountDto>>(entity);
        }

        public IResult Update(DiscountDto discountDto)
        {
            var entity = _mapper.Map<DiscountDto, Discount>(discountDto);
             _discountDal.Update(entity);
            _discountDal.Complete();
            return new SuccessResult();
        }
    }
}
