using Planer.Models.Enums;

namespace Planer.Models.Commands
{
    public class Command
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Kind { get; set; }
        
    }
}
