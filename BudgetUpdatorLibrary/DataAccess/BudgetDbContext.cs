using BudgetUpdatorAppLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace BudgetUpdatorLibrary;
public class BudgetDbContext : DbContext
{
    public DbSet<BudgetItem> BudgetItems { get; set; }
    public DbSet<SettingsConfig> Settings { get; set; }
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
