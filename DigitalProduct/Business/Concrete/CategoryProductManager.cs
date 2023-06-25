using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract.EntityFramework;
using Entities.DTOs;
using Entities.DTOs.CategoryProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryProductManager : ICategoryProductService
    {
        ICategoryProductDal _categoryProductDal;

        public CategoryProductManager(ICategoryProductDal categoryProductDal)
        {
            _categoryProductDal = categoryProductDal;
        }

        public IDataResult<List<ProductDto>> GetByCategoryList(int id)
        {
            var response = _categoryProductDal.GetByCategoryId(id);
            return new SuccessDataResult<List<ProductDto>>(response);
        }

        public IDataResult<CategoryProductResponse> GetByID(int id)
        {
            var response = _categoryProductDal.GetById(id);
            return new SuccessDataResult<CategoryProductResponse>(response);

        }

        public IDataResult<List<CategoryProductResponse>> GetList()
        {
            var response = _categoryProductDal.GetAll();
            return new SuccessDataResult<List<CategoryProductResponse>>(response);

        }
    }
}
