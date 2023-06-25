using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfGenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(EfDbContext context) : base(context)
        {

        }
    }
}
