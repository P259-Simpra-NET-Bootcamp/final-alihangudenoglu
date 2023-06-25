using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfGenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(EfDbContext context) : base(context)
        {

        }
    }
}
