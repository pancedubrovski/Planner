using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Planer.Database;
using Planer.Models;
using Planer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Planer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly PlannerContext _plannerContext;

        public GenericRepository(PlannerContext plannerContext)
        {
            _plannerContext = plannerContext;
        }

        public async Task<bool> Add(TEntity command)
        {
            await _plannerContext.Set<TEntity>().AddAsync(command);
            _plannerContext.SaveChanges();
            return true;
        }

        public async Task<List<TEntity>> GetList<TEnity>(Expression<Func<TEntity, bool>> predicate, List<string> includes)
        {
            var query = _plannerContext.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(predicate).ToListAsync();
        }
        public async Task<TEntity> GetElementById(object id)
        {
            return await _plannerContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<bool> DeleteElement(object id)
        {

            var entityToDelete = await  GetElementById(id);

            if (_plannerContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _plannerContext.Set<TEntity>().Attach(entityToDelete);
            }
            _plannerContext.Set<TEntity>().Remove(entityToDelete);
            return true;
        }

        public async Task<bool> Update(TEntity entity)
        {
            _plannerContext.Set<TEntity>().Attach(entity);
            _plannerContext.Entry(entity).State = EntityState.Modified;
            await _plannerContext.SaveChangesAsync();
            return true;
        }
    }
}
