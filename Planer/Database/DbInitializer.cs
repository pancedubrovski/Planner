using Microsoft.EntityFrameworkCore;
using Planer.Models;
using Planer.Models.Enums;

namespace Planer.Database
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Category>().HasData(
                   new Category() { Id = 1, Value = "Food", Kind = CategoryKind.Expenses },
                   new Category() { Id = 2, Value = "Transport", Kind = CategoryKind.Expenses },
                   new Category() { Id = 3, Value = "Bills", Kind = CategoryKind.Expenses },
                   new Category() { Id = 4, Value = "Other", Kind = CategoryKind.Expenses },
                   new Category() { Id = 5, Value = "Salary", Kind = CategoryKind.Income },
                   new Category() { Id = 6, Value = "TravelCosts", Kind = CategoryKind.Income },
                   new Category() { Id = 7, Value = "Other", Kind = CategoryKind.Income }
            );
        }
    }
}
