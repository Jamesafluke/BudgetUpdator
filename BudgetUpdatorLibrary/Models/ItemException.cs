namespace BudgetUpdatorLibrary.Models;
public class ItemException
{
    public int Id { get; set; }
    public string? Item { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool Remove { get; set; }
}
