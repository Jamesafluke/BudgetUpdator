using Microsoft.Office.Interop.Excel;

namespace BudgetUpdatorLibrary;
static public class Utilities
{
    static public bool XlsxIsOpen()
    {
        try
        {
            Stream s = File.Open(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName),
                                 FileMode.Open,
                                 FileAccess.Read,
                                 FileShare.None);

            s.Close();

            return false;
        }
        catch (Exception)
        {
            return true;
        }
    }

    static public bool CsvsExist()
    {
        if (File.Exists(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName))
            && File.Exists(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv2FileName)))
        {
            return true;
        }
        else { return false; }
    }

    static public string GetLastUpdatedTimeStamp()
    {
        //TODOGetLastUpdatedTimeStamp
        return "Never";
    }

    static public bool PendingItemsExist()
    {
        //TODO CheckForCompleteItems
        return false;
    }

}
