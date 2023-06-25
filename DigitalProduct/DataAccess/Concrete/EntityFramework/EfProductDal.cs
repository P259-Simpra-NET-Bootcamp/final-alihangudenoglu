using DataAccess.Abstract.EntityFramework;
using DataAccess.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfGenericRepository<Product>,IProductDal
    {
        private readonly DbContextOptions<EfDbContext> _options;

        public EfProductDal(DbContextOptions<EfDbContext> options) : base(new EfDbContext(options))
        {
            _options = options;
        }

        public List<Product> GetCategory()
        {
            using (var context = new EfDbContext(_options))
            {

                return (from cs in context.Products                     
                        orderby cs.Id ascending
                        select new Product
                        {
                            CategoryProducts = (from cate in cs.CategoryProducts
                                                select new CategoryProduct
                                                {
                                                    CategoryId = cate.Id,
                                                    ProductId = cate.ProductId,
                                                }).ToList(),
                            Id = cs.Id,
                            Name = cs.Name,
                           
                        }).ToList();  
            }
        }
    }
}
