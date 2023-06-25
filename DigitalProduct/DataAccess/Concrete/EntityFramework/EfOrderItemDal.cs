using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderItemDal : EfGenericRepository<OrderItem>, IOrderItemDal
    {
        public EfOrderItemDal(EfDbContext context) : base(context)
        {

        }
    }
}
