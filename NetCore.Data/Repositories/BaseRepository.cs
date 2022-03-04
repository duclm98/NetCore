﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetCore.Data.Context;
using NetCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Data.Repositories
{
    public class BaseRepository<TEntity> where TEntity : Base
    {
        internal NetCoreDbContext context;
        internal DbSet<TEntity> dbSet;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseRepository(NetCoreDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
            this.httpContextAccessor = httpContextAccessor;
        }

        public virtual IQueryable<TEntity> Queryable =>
            dbSet.Where(x => x.DeletedAt == null);

        public virtual async Task<TEntity> GetByID(object id)
        {
            var record = await dbSet.FindAsync(id);
            if (record == null || record.DeletedAt != null)
                return null;
            return record;
        }

        public virtual async Task Insert(TEntity entity)
        {
            entity.CreatorId = GetCreator();
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Insert(List<TEntity> entities)
        {
            var creator = GetCreator();
            entities.Select(x =>
            {
                x.CreatorId = creator;
                return x;
            });
            await dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(List<TEntity> entities)
        {
            entities.Select(x =>
            {
                x.UpdatedAt = DateTime.Now;
                return x;
            });
            dbSet.AttachRange(entities);
            context.Entry(entities).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            entity.DeletedAt = DateTime.Now;
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(List<TEntity> entities)
        {
            entities.Select(x =>
            {
                x.DeletedAt = DateTime.Now;
                return x;
            });
            dbSet.AttachRange(entities);
            context.Entry(entities).State = EntityState.Modified;
        }

        private int? GetCreator()
        {
            int? creator = null;
            var httpContextUserId = httpContextAccessor.HttpContext?.Items["userId"];
            if (httpContextUserId != null)
                creator = (int?)httpContextUserId;
            return creator;
        }
    }
}