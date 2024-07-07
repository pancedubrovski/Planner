using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Planer.Database;
using Planer.Models;
using Planer.Models.Commands;
using Planer.Repositories.Interfaces;
using Planer.Models.Responses;
using Planer.Models.Enums;

namespace Planer.Repositories
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        public readonly PlannerContext _context;
        private readonly IMapper _mapper;
        public IncomeRepository(PlannerContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> SaveIncome(Command command)
        {
            Income income = _mapper.Map<Income>(command);
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == command.CategoryId);
            income.Category = category;


            await  _context.Incomes.AddAsync(income);
            // await Add(income);

            _context.SaveChanges();

            return true;
        }


        public async Task<bool> UpdateIncome(int id,UpdateCommand command)
        {
            var entity = await GetElementById(id);
            entity.Year = command.Year;
            entity.Month = command.Month;
            entity.Amount = command.Amount;

            await Update(entity);
            return true;
        }


        public async Task<List<IncomeExpensesResponse>> GetIncomes()
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
