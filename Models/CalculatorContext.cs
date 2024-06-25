using System.Data.Entity;

namespace ProductionProcessCompanion.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext() : base("name=ConnectionString") { }

        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<City> City { get; set; }
    }
}
