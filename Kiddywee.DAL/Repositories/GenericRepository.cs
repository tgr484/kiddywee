using Kiddywee.DAL.Data;
using Kiddywee.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public GenericRepository(FileDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null) query = query.Where(filter);
            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null) query = orderBy(query);

            var model = query.AsNoTracking().ToList();

            return model;
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null) query = query.Where(filter);
            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null) query = orderBy(query);

            var model = await query.AsNoTracking().ToListAsync();

            return model;
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null) query = query.Where(filter);

            if (include != null)
            {
                query = include(query);
            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null) query = query.Where(filter);

            if (include != null)
            {
                query = include(query);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Insert(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task InsertRange(List<TEntity> items)
        {
            await _dbSet.AddRangeAsync(items);
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);
        }

        public void UpdateRange(List<TEntity> items)
        {
            _dbSet.UpdateRange(items);
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void DeleteRange(List<TEntity> items)
        {
            _dbSet.RemoveRange(items);
        }
    }
}
