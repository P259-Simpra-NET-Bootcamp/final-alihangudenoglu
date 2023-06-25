using DataAccess.Abstract.EntityFramework;
using DataAccess.Context;
using Entities.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class,IEntity
    {
        protected readonly EfDbContext dbContext;
        private bool disposed;

        public EfGenericRepository(EfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Set<TEntity>().Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }
        public List<TEntity> GetAllAsNoTracking()
        {
            return dbContext.Set<TEntity>().AsNoTracking().ToList();
        }
        public List<TEntity> GetAllWithInclude(params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }
        public TEntity GetByIdWithInclude(int id, params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<TEntity> WhereWithInclude(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            query.Where(expression);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            return query.ToList();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
        public TEntity GetById(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }
        public TEntity GetByIdAsNoTracking(int id)
        {
            return dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        

        public void Insert(TEntity entity)
        {

            dbContext.Set<TEntity>().Add(entity);
        }
        public void InsertRange(IEnumerable<TEntity> entities)
        {

            dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return dbContext.Set<TEntity>().Where(expression).AsQueryable();
        }
        public IEnumerable<TEntity> WhereAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return dbContext.Set<TEntity>().AsNoTracking().Where(expression).AsQueryable();
        }

        public void Complete()
        {
            dbContext.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbDcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging
                    dbDcontextTransaction.Rollback();
                }
            }
        }


        private void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }
        public void Dispose()
        {
            Clean(true);
        }
    }
}
