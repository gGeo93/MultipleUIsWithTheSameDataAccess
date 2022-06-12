using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity?> Get(int id) 
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll() 
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate) 
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task Add(TEntity entity) 
        {
            await context.Set<TEntity>().AddAsync(entity);
        }
        public async Task AddRange(IEnumerable<TEntity> entities) 
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Remove(TEntity entity) 
        {
            context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities) 
        {
            context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
