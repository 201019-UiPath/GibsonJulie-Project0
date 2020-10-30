using System;
using SoilMatesDB;
using SoilMatesUI.Menu;


namespace SoilMatesUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new MainMenu(new SoilMatesContext());
            menu.Start();
            //menu.SelectSignInMenu();
        }
    }
}
