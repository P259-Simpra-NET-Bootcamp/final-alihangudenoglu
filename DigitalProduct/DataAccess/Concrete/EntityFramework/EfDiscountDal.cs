using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDiscountDal : EfGenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(EfDbContext context) : base(context)
        {

        }
    }
}
