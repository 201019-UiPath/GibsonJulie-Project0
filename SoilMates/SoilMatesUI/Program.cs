using System;
using SoilMatesUI.Menu;
using SoilMatesLib;

namespace SoilMatesUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IMenu menu = new MainMenu();
            menu.Greeting();
            menu.SelectSignInMenu();

        }
    }
}
