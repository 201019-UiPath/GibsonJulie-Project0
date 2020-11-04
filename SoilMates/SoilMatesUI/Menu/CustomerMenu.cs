using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;
using System.Collections.Generic;

namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Customer specific menu user interface
    /// </summary>
    public class CustomerMenu
    {
        IRepository repo;
        InventoryMenu inventoryMenu;
        private string userInput;
        private IMenuBL menuBL = new MenuBL();
        OrderMenu orderMenu;

        /// <summary>
        /// Customer menu constructor
        /// </summary>
        /// <param name="repo"></param>
        public CustomerMenu(IRepository repo)
        {
            this.repo = repo;
            this.orderMenu = new OrderMenu(repo);
            this.inventoryMenu = new InventoryMenu(repo);
        }

        /// <summary>
        /// Entry point for customer UI
        /// </summary>
        /// <param name="user"></param>
        public void Start(Customer user)
        {
            Console.WriteLine();
            Console.WriteLine("{0}, Welcome to SoilMates Plant Store!", user.Name);

            bool isValidMenuItem;
            do
            {
                PrintCustomerMenuOptions();
                isValidMenuItem = menuBL.CustomerMenuInputValidation(userInput);

                if (isValidMenuItem && userInput.Equals("0"))
                {
                    orderMenu.OrderPlant(user);
                }

                if (isValidMenuItem && userInput.Equals("1"))
                {
                    orderMenu.GetOrderHistory(user);

                }
                if (isValidMenuItem && userInput.Equals("2"))
                {
                    inventoryMenu.GetLocationInventory();
                }
            } while (!isValidMenuItem || !userInput.Equals("x"));
        }

        /// <summary>
        /// prints menu options for customer
        /// </summary>
        public void PrintCustomerMenuOptions()
        {
            Console.WriteLine("[0] Order A Plant");
            Console.WriteLine("[1] View Order History");
            Console.WriteLine("[2] View Location Inventory"); //TODP
            Console.WriteLine("[x] Exit");

            userInput = Console.ReadLine();
        }
    }
}