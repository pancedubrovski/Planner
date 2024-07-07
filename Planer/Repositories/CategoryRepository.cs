using Planer.Database;
using Planer.Models;
using Planer.Repositories.Interfaces;

namespace Planer.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public readonly PlannerContext _context;
        public CategoryRepository(PlannerContext context) : base(context)
        {
            _context = context;
        }
    }
}
