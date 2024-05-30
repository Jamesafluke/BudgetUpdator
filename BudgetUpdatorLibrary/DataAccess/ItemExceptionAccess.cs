using BudgetUpdatorLibrary.Models;

namespace BudgetUpdatorLibrary.DataAccess;
public class ItemExceptionAccess
{
    public static void AddItemException(ItemException itemException)
    {
        using (var db = new BudgetDbContext())
        {
            db.ItemExceptions.Add(itemException);
            db.SaveChanges();
        }
    }

    public static void RemoveItemException(int id)
    {
        using (var db = new BudgetDbContext())
        {
            ItemException item = db.ItemExceptions.Where(b => b.Id == id).First();
            db.ItemExceptions.Remove(item);
            db.SaveChanges();
        }
    }

    public static void RemoveItemException(string item)
    {
        using (var db = new BudgetDbContext())
        {
            ItemException itemException = db.ItemExceptions.Where(b => b.Item == item).First();
            db.ItemExceptions.Remove(itemException);
            db.SaveChanges();
        }
    }

    public static List<ItemException> GetItemExceptions()
    {
        using (var db = new BudgetDbContext())
        {
            List<ItemException> itemExceptions = db.ItemExceptions.ToList();
            return itemExceptions;
        }
    }
}
