using BudgetUpdatorAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BudgetUpdatorLibrary;
public static class BudgetAccess
{
    public static void AddBudgetItem(BudgetItem budgetItem)
    {
        using (var db = new BudgetDbContext())
        {
            db.BudgetItems.Add(budgetItem);
            db.SaveChanges();
        }
    }

    public static void RemoveBudgetItem(int id)
    {
        using (var db = new BudgetDbContext()){
            BudgetItem item = db.BudgetItems.Where(b => b.Id == id).First();
            db.BudgetItems.Remove(item);
        }
    }

    public static void UpdateBudgetItem(BudgetItem budgetItem)
    {
        using (var db = new BudgetDbContext())
        {
            var existingItem = db.BudgetItems.FirstOrDefault(b => b.Id == budgetItem.Id);
            db.RemoveRange(existingItem);
            db.Add(budgetItem);
            db.SaveChanges();
        }
    }

    public static List<BudgetItem> GetAllBudgetItems()
    {
        using (var db = new BudgetDbContext())
        {
            List<BudgetItem> budgetItems = db.BudgetItems.ToList();
            return budgetItems;
        }
    }

    public static void ClearDb()
    {
        using (var db = new BudgetDbContext())
        {
            db.BudgetItems.RemoveRange(db.BudgetItems);
            db.SaveChanges();
        }
    }
}
