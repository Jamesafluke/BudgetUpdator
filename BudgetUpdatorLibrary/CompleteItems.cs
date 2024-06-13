using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary.Migrations;

namespace BudgetUpdatorLibrary;
public class CompleteItems
{
    private static readonly CompleteItems _instance = new CompleteItems();
    private int _counter = 0;
    private List<BudgetItem> _stagedItems = new List<BudgetItem>();
    public List<BudgetItem> IncompleteItems { get; set; } = new List<BudgetItem>();

    private CompleteItems()
    {
        UpdateIncompleteItemsStarter();
    }

    public static CompleteItems GetCompleteItems()
    {
        return _instance;
    }

    public void UpdateIncompleteItemsStarter()
    { 
        //This method smells like bad practice? I'm only doing it to unit test. :/ 
        UpdateIncompleteItems(BudgetAccess.GetAllBudgetItems(), SettingsAccess.GetSettings(), DateTime.Now);
    }

    public void UpdateIncompleteItems(List<BudgetItem> budgetItems, SettingsConfig settingsConfig, DateTime today)
    {
        DateTime month;
        if (settingsConfig.SelectPreviousMonth) { month = today.AddMonths(-1); }
        else { month = today; }
        foreach (var i in budgetItems)
        {
            if (i.Date.Month == month.Month && (i.Category is null || i.Category == ""))
            {
                IncompleteItems.Add(i);
            }
        }
        //_logger.LogInformation($"{IncompleteItems.Count} incomplete items.");
    }

    public int GetIncompleteItemsCount()
    {
        return IncompleteItems.Count;
    }

    public bool IncompleteItemsExist()
    {
        if(IncompleteItems is not null && IncompleteItems.Count > 0)
        {
            return true;
        }
        else { return false; }
    }

    public BudgetItem GetNextIncompleteItem()
    {
        return IncompleteItems[_counter];
    }

    public void StageItem(BudgetItem budgetItem)
    {
        _stagedItems.Add(budgetItem);
        _counter++;
    }

    public bool AllComplete()
    {
        if(_counter == IncompleteItems.Count) { return true; }
        return false;
    }

    public void WriteStagedItemsToDb()
    {
        foreach (var budgetItem in _stagedItems)
        {
            BudgetAccess.UpdateBudgetItem(budgetItem);
        }
        _stagedItems.Clear();
        
    }

    public int GetCounter()
    {
        return _counter;
    }

    public void Resetcounter()
    {
        _counter = 0;
    }

}
