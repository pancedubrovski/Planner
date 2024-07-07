using Planer.Models;
using System.Linq.Expressions;

namespace Planer.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> GetList<TEnity>(Expression<Func<TEntity, bool>> predicate, List<string> includes);
        public Task<bool> Add(TEntity command);

        public Task<bool> DeleteElement(object id);

    }
}
