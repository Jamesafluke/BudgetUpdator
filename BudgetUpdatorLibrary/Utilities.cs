using Microsoft.Office.Interop.Excel;

namespace BudgetUpdatorLibrary;
static public class Utilities
{
    static public bool XlsxIsClosed()
    {
        try
        {
            Stream s = File.Open(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName),
                                 FileMode.Open,
                                 FileAccess.Read,
                                 FileShare.None);

            s.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
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

    public static void DeleteCsvs()
    {
        File.Delete(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName));        
        File.Delete(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName));        
    }

}
