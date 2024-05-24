using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using Microsoft.EntityFrameworkCore;



namespace BudgetUpdatorDataLibrary;
public class BudgetDbContext : DbContext
{
    public DbSet<BudgetItem> budgetItems { get; set; }
    public string DbPath { get; }

    public BudgetDbContext()
    {
        DbPath = Path.Combine(GlobalConfig.dbPath, GlobalConfig.dbFile);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
