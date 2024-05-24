namespace BudgetUpdatorAppLibrary;
public class BudgetItem
{
    public int? Id { get; set; }
    public DateTime Date { get; set; }
    public string? Item { get; set; }
    public string? Description { get; set; }
    public string? Method { get; set; }
    public string? Category { get; set; }
    public decimal Amount { get; set; }
    public List<BudgetItem>? SplitBudgetItems { get; set; }
    public bool ExportedToBudget { get; set; } = false;
    public bool Deleted { get; set; } = false;
    public bool ManuallyAdded { get; set; } = false;
}
