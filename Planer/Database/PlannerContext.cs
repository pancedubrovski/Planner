using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Planer.Models;
using Planer.Models.Enums;
using System.Xml;

namespace Planer.Database
{
    public class PlannerContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public PlannerContext() { }

        public PlannerContext(DbContextOptions<PlannerContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DbInitializer(modelBuilder).Seed();

            modelBuilder.Entity<Income>()
                .HasOne(a => a.Category);


            modelBuilder.Entity<Expenses>()
               .HasOne(a => a.Category);


        }
    }
}
