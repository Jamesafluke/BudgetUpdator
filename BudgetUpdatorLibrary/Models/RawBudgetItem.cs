using CsvHelper.Configuration.Attributes;

namespace BudgetUpdatorAppLibrary;
public class RawBudgetItem
{
    [Index(0)]
    public string AccountNumber { get; set; }
    [Index(1)]
    public string PostDate { get; set; }
    public string Check { get; set; }
    public string Description { get; set; }
    public string Debit { get; set; }
    public string Credit { get; set; }
    public string Status { get; set; }
    public string Balance { get; set; }
    public string Classification { get; set; }
}
