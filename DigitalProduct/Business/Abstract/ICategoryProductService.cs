using Core.Utilities.Results;
using Entities.DTOs;
using Entities.DTOs.CategoryProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryProductService
    {
        IDataResult< List<CategoryProductResponse>> GetList();
        IDataResult<CategoryProductResponse> GetByID(int id);
        IDataResult<List<ProductDto>> GetByCategoryList(int id);
    }
}