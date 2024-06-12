using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary.Migrations;

namespace BudgetUpdatorLibrary;
public class CompleteItems
{
    public List<BudgetItem> IncompleteItems { get; set; }

    public void UpdateIncompleteItemsStarter()
    { 
        //This method smells like bad practice; I'm only doing it to unit test. :/ 
        UpdateIncompleteItems(BudgetAccess.GetAllBudgetItems());
    }

    public void UpdateIncompleteItems(List<BudgetItem> budgetItems)
    {
        foreach (var i in budgetItems)
        {
            if (i.Description == "" || i.Category == "")
            {
                IncompleteItems.Add(i);
            }
        }
    }

    public int GetIncompleteItemsCount()
    {
        throw new NotImplementedException();
    }
}
