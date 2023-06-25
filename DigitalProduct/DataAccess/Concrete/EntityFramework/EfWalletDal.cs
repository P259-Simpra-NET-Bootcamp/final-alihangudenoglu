using DataAccess.Context;
using DataAccess.Abstract.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWalletDal : EfGenericRepository<Wallet>, IWalletDal
    {
        public EfWalletDal(EfDbContext context) : base(context)
        {

        }
    }
}
