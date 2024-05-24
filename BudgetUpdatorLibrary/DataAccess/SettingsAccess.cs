using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetUpdatorLibrary;
public static class SettingsAccess
{
    public static void ApplySettings(SettingsConfig settingsConfig)
    {

        using (var db = new BudgetDbContext())
        {
            db.Settings.Remove(db.Settings.FirstOrDefault());

            db.Settings.Add(settingsConfig);
            
            db.SaveChanges();
        }
    }

    public static SettingsConfig GetSettings()
    {

        using (var db = new BudgetDbContext())
        {
            var settingsConfig = db.Settings.FirstOrDefault();
            if(settingsConfig != null) { return settingsConfig; }
            else{ return new SettingsConfig(0.0, true, false); }
        }
    }
}
