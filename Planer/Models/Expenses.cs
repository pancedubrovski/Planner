using Planer.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planer.Models
{
    public class Expenses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        [Required]
        public Category Category { get; set; }
        public double Amount { get; set; }
        public Kind Kind { get; set; }
    }
}
