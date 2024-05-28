using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using SQLitePCL;
using System.Runtime.InteropServices;

namespace BudgetUpdatorUI;

internal class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //Launch console.
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        AllocConsole();

        


        IHostBuilder hostBuilder = new HostBuilder();

        hostBuilder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole(option =>
            {
                option.FormatterName = ConsoleFormatterNames.Systemd;
            });
        });

        var host = hostBuilder.Build();
        var programLogger = host.Services.GetRequiredService<ILogger<Program>>();
        var menuLogger = host.Services.GetRequiredService<ILogger<MenuForm>>();


        //Something about initializing the db.
        SQLitePCL.Batteries.Init();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MenuForm(menuLogger));
    }
}