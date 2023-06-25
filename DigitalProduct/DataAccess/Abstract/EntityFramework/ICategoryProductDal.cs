using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CategoryProducts;

namespace DataAccess.Abstract.EntityFramework
{
    public interface ICategoryProductDal : IGenericRepository<CategoryProduct>
    {
        List<CategoryProductResponse> GetAll();
        CategoryProductResponse GetById(int id);
        List<ProductDto> GetByCategoryId(int categoryId);
    }
}
