using BudgetPlanner.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.DataAccess
{
    public class ApplicationDBContext : DbContext
    {


        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> options) : base(options) 
        {
            
         
            
        }

        public DbSet<Expense> Expenses { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expense>().ToTable("Expenses");
        }
    }


}
