using Microsoft.EntityFrameworkCore;
using NetCore.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        internal NetCoreDbContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(NetCoreDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Queryable =>
            dbSet.AsQueryable();

        public virtual async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Insert(List<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(List<TEntity> entities)
        {
            dbSet.AttachRange(entities);
            context.Entry(entities).State = EntityState.Modified;
        }
    }
}