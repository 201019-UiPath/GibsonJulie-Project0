using System;
using SoilMatesDB;
using SoilMatesUI.Menu;
using Serilog;

namespace SoilMatesUI
{
    /// <summary>
    /// Console app for SoilMates
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(@"../Log/Log.txt")
            .CreateLogger();

            IMenu menu = new MainMenu(new SoilMatesContext());
            menu.Start();
        }
    }
}
