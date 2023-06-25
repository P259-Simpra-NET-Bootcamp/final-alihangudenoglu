using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        T GetById(int id);
        T GetByIdAsNoTracking(int id);
        T GetByIdWithInclude(int id, params string[] includes);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void DeleteById(int id);
        void Delete(T entity);
        List<T> GetAll();
        IQueryable<T> GetAsQueryable();
        List<T> GetAllAsNoTracking();
        List<T> GetAllWithInclude(params string[] includes);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        IEnumerable<T> WhereAsNoTracking(Expression<Func<T, bool>> expression);
        IEnumerable<T> WhereWithInclude(Expression<Func<T, bool>> expression, params string[] includes);

        void Complete();
        void CompleteWithTransaction();
    }
}
