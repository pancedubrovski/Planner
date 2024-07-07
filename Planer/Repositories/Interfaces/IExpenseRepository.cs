using Planer.Models;
using Planer.Models.Commands;
using Planer.Models.Responses;

namespace Planer.Repositories.Interfaces
{
    public interface IExpenseRepository : IGenericRepository<Expenses>
    {
        public Task<bool> SaveExpense(Command command);

        public Task<bool> UpdateExpenese(int id,UpdateCommand command);

        public Task<List<IncomeExpensesResponse>> GetExpneses();

    }
}
