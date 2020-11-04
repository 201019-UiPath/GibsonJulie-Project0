using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class ManagerMenu
    {
        IRepository repo;
        private string userInput;
        private IMenuBL menuBL = new MenuBL();
        private LocationMenu locationMenu;

        private AddProductMenu productMenu;

        private InventoryMenu inventoryMenu;

        public ManagerMenu(IRepository repo)
        {
            this.repo = repo;
            this.locationMenu = new LocationMenu(repo);
            this.productMenu = new AddProductMenu(repo);
            this.inventoryMenu = new InventoryMenu(repo);
        }

        public void Start(Manager user)
        {
            Console.WriteLine();
            bool isValidMenuItem;
            do
            {
                Console.WriteLine("Hello {0}, Welcome to SoilMates Employee Portal: ", user.Name);
                PrintManagerMenuOptions();
                isValidMenuItem = menuBL.EmployeeMenuInputValidation(userInput); //CHANGE THIS

                if (isValidMenuItem && userInput.Equals("0")) locationMenu.Start();
                if (isValidMenuItem && userInput.Equals("1")) productMenu.Start();
                if (isValidMenuItem && userInput.Equals("2")) inventoryMenu.AddPlantToInventory();
                if (isValidMenuItem && userInput.Equals("3")) inventoryMenu.PrintStoreInvetory();
                if (isValidMenuItem && userInput.Equals("4")) inventoryMenu.PrintPlantInventory();
                if (isValidMenuItem && userInput.Equals("5")) locationMenu.OrderAtLocation();

            } while (!isValidMenuItem || !userInput.Equals("x"));
        }

        public void PrintManagerMenuOptions()
        {
            Console.WriteLine("[0] Add location"); //TODO possibly remove but managers can add locations for now
            Console.WriteLine("[1] Add plant to stock");
            Console.WriteLine("[2] Add plant to Store location");
            Console.WriteLine("[3] Print Store Inventory"); //Check products in store location
            Console.WriteLine("[4] Print Plant Inventory");  //Check product inventory by product type
            Console.WriteLine("[5] Print Order History By Location");
            Console.WriteLine("[x] Exit"); //remove product
            userInput = Console.ReadLine();
        }

    }
}
