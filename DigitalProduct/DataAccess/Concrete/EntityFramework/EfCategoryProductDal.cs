using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs.CategoryProducts;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryProductDal : EfGenericRepository<CategoryProduct>, ICategoryProductDal
    {

        private readonly DbContextOptions<EfDbContext> _options;

        public EfCategoryProductDal(DbContextOptions<EfDbContext> options) : base(new EfDbContext(options))
        {
            _options = options;
        }

        public List<ProductDto> GetByCategoryId(int categoryId)
        {
            using (EfDbContext context = new EfDbContext(_options))
            {
                var result = from p in context.Products
                             join cp in context.CategoryProducts
                             on p.Id equals cp.ProductId
                             where cp.CategoryId == categoryId
                             select new ProductDto
                             {
                                 Description = p.Description,
                                 Guarantee = p.Guarantee,
                                 MaxPuan = p.MaxPuan,
                                 Name = p.Name,
                                 Price = p.Price,
                                 PuanPercent = p.PuanPercent,
                                 Status = p.Status,
                                 Stock = p.Stock,
                                 CategoryProducts = new List<Items> { new Items { CategoryId = categoryId } }
                             };
                return result.ToList();
            }
        }

        List<CategoryProductResponse> ICategoryProductDal.GetAll()
        {
            throw new NotImplementedException();
        }

        CategoryProductResponse ICategoryProductDal.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
