using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Planer.Database;
using Planer.Models;
using Planer.Models.Commands;
using Planer.Models.Responses;
using Planer.Repositories.Interfaces;

namespace Planer.Repositories
{
    public class ExpenseRepository: GenericRepository<Expenses>, IExpenseRepository
    {
        public readonly PlannerContext _context;
        private readonly IMapper _mapper;
        public ExpenseRepository(PlannerContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> SaveExpense(Command command)
        {
            Expenses expenses = _mapper.Map<Expenses>(command);
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == command.CategoryId);
            expenses.Category = category;

            await _context.Expenses.AddAsync(expenses);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateExpenese(int id, UpdateCommand command)
        {
            var entity = await GetElementById(id);
            entity.Year = command.Year;
            entity.Month = command.Month;
            entity.Amount = command.Amount;

            await Update(entity);
            return true;
        }

        public async Task<List<IncomeExpensesResponse>> GetExpneses()
        {
            var list = await GetList<Income>(i => true, new List<string>() { "Category" });
            List<IncomeExpensesResponse> response = new List<IncomeExpensesResponse>();
            list.ForEach(e =>
            {
                var element = _mapper.Map<IncomeExpensesResponse>(e);
                response.Add(element);
            });
            return response;
        }


    }
}
