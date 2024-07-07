using Planer.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planer.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Value { get; set; }
        public CategoryKind Kind { get; set; }
    }
}
