using Planer.Models;
using Planer.Models.Commands;
using Planer.Models.Responses;

namespace Planer.Repositories.Interfaces
{
    public interface IIncomeRepository : IGenericRepository<Income> 
    {
        public Task<bool> SaveIncome(Command command);
        public Task<bool> UpdateIncome(int id, UpdateCommand command);
        public Task<List<IncomeExpensesResponse>> GetIncomes();
    }
}
