using Core.Utilities.Results;
using Entities.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDiscountService
    {
        public IResult Add(DiscountDto discountDto);
        public IResult Update(DiscountDto discountDto);
        public IResult Delete(int id);
        public IDataResult<DiscountDto> GetById(int id);
        public IDataResult<List<DiscountDto>> GetByUserId(int id);
        public IDataResult<List<DiscountDto>> GetAll();
    }
}
