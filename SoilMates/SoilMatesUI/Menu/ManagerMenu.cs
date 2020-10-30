using System.Reflection;
using System.Data.Common;
using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class ManagerMenu
    {
        CustomerService customerService;
        ManagerService managerService;

        ProductService productService;

        IRepository repo;

        private string userInput;

        private IMenuBL menuBL = new MenuBL();

        public ManagerMenu(IRepository repo)
        {
            this.repo = repo;
            this.customerService = new CustomerService(repo);
            this.managerService = new ManagerService(repo);
            this.productService = new ProductService(repo);
        }

        public void Start(Manager user)
        {
            Console.WriteLine();
            Console.WriteLine("Hello {0}, Welcome to SoilMates Employee Portal: ", user.Name);

            bool isValidMenuItem;
            do
            {
                PrintManagerMenuOptions();
                isValidMenuItem = menuBL.CustomerMenuInputValidation(userInput); //CHANGE THIS
                if (isValidMenuItem && userInput.Equals("0"))
                {
                    Location location = new Location();
                    repo.AddLocation(location);
                }

            } while (!isValidMenuItem || !userInput.Equals("x"));

        }

        public void PrintManagerMenuOptions()
        {
            Console.WriteLine("[0] Add location"); //TODO possibly remove but managers can add locations for now
            Console.WriteLine("[0] Print Store Inventory"); //Check products in store location
            Console.WriteLine("[1] Print Plant Inventory");  //Check product inventory by product type
            Console.WriteLine("[2] Add Product to Inventory"); //add new product
            Console.WriteLine("[3] Remove Product from inventory"); //remove product
            Console.WriteLine("[x] Exit"); //remove product
            userInput = Console.ReadLine();
        }

    }
}
