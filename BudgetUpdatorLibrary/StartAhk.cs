using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BudgetUpdatorLibrary;
public class StartAhk
{
    ILogger _logger;
    public StartAhk(ILogger logger)
    {
        _logger = logger;
    }

    //TODO Create StartAHK
    public void LaunchAHK()
    {
        _logger.LogInformation("Starting AHK.");
        Process process = new Process();

        process.StartInfo.FileName = Path.Combine(GlobalConfig.ahkPath, GlobalConfig.ahkFileName);
        process.StartInfo.Arguments = $"{Path.Combine(GlobalConfig.ahkScriptPath, GlobalConfig.ahkScriptFileName)}";
        process.EnableRaisingEvents = true;
        process.Start();
        process.WaitForExit();
        _logger.LogInformation("AHK done.");
    }    
    
}
