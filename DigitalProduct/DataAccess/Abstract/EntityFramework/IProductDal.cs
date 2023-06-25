using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IProductDal:IGenericRepository<Product>
    {
        public List<Product> GetCategory();
    }
}
