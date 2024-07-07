using Planer.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Planer.Models.Responses
{
    public class IncomeExpensesResponse
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Category Category { get; set; }
        public double Amount { get; set; }
        public string Kind { get; set; }
    }
}
