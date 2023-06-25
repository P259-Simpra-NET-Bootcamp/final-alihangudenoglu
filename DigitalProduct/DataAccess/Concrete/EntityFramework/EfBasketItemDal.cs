using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketItemDal : EfGenericRepository<BasketItem>, IBasketItemDal
    {
        public EfBasketItemDal(EfDbContext context) : base(context)
        {

        }
    }
}
