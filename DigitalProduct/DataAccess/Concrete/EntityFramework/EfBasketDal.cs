using DataAccess.Abstract.EntityFramework;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfGenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(EfDbContext context) : base(context)
        {

        }
    }
}
