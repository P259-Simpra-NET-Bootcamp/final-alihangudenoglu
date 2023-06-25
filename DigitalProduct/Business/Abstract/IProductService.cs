using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        
        public IResult Add(ProductDto productDto);
        public IResult Update(ProductDto productDto);
        public IResult Delete(int id);
        public IDataResult<ProductDto> GetById(int id);
        public IDataResult<List<ProductDto>> GetAll();
    }
}
