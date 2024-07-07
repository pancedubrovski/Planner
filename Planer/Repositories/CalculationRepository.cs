using Microsoft.EntityFrameworkCore;
using Planer.Database;
using Planer.Models.Responses;
using Planer.Repositories.Interfaces;


namespace Planer.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {

        private readonly PlannerContext _context;
        public CalculationRepository(PlannerContext context)
        {
            _context = context;
        
        }

        public async Task<BugetResponse> CalcuateBuget()
        {


            var incomeRes = await _context.Incomes.Join(
                 _context.Categories,
                income => income.Id,
                category => category.Id,
                (income, category) => new
                {
                    Year = income.Year,
                    Month = income.Month,
                    Kind = income.Kind,
                    Amount = income.Amount,
                    Category = category.Value,


                }).GroupBy(i => new
                {
                    i.Category,
                    i.Year,
                    i.Month,
                    i.Kind
                }).Select(r => new Item
                {
                    Category = r.Key.Category,
                    Year = r.Key.Year,
                    Month = r.Key.Month,
                    Kind = r.Key.Kind.ToString(),
                    Amount = r.Sum(s => s.Amount)
                }).ToListAsync();

            var expnesesRes = await _context.Expenses.Join(
                 _context.Categories,
                income => income.Id,
                category => category.Id,
                (income, category) => new
                {
                    Year = income.Year,
                    Month = income.Month,
                    Kind = income.Kind,
                    Amount = income.Amount,
                    Category = category.Value,


                })
                .GroupBy(i => new
                {
                    i.Category,
                    i.Year,
                    i.Month,
                    i.Kind
                })
                .Select(r => new Item
                {
                    Category = r.Key.Category,
                    Year = r.Key.Year,
                    Month = r.Key.Month,
                    Kind = r.Key.Kind.ToString(),
                    Amount = r.Sum(s => s.Amount)
                }).ToListAsync();


            var result = new BugetResponse
            {
                Incomes = incomeRes,
                Expenses = expnesesRes
            };
            return result;
        }

    }
}
