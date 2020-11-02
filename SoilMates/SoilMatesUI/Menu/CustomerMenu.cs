using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;
using System.Collections.Generic;

namespace SoilMatesUI.Menu
{
    public class CustomerMenu
    {
        ProductService productService;
        LocationService locationService;
        InventoryService inventoryService;
        IRepository repo;
        private string userInput;
        private IMenuBL menuBL = new MenuBL();

        public CustomerMenu(IRepository repo)
        {
            this.repo = repo;
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
        }


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


                    Console.WriteLine("Select the store to shop from by id:");
                    foreach (var store in locationService.GetAllLocations())
                    {
                        Console.WriteLine($"\tlocations: {store.Name} \t{store.LocationId} \tAddress: {store.Address}");
                    }

                    int storeID = Int32.Parse(Console.ReadLine());
                    Location customerLocation = locationService.GetLocationById(storeID);
                    List<Inventory> customerInventory = customerLocation.StoreProducts;

                    do
                    {
                        Console.WriteLine("Select a product by id");
                        foreach (var invetoryItem in customerInventory)
                        {
                            Console.WriteLine($"\tProduct: {invetoryItem.Product.Name} id: {invetoryItem.Product.ProductId}");
                        }

                        int productId = Int32.Parse(Console.ReadLine());
                        Product soldProduct = productService.GetProduct(productId);
                        productService.RemoveProduct(soldProduct);

                        Console.WriteLine("Type [x] to finish");
                        string input = Console.ReadLine();
                        if (input.Equals("x"))
                        {
                            break;
                        }
                    } while (true);

                    Order order = new Order();
                    order.OrderTime = DateTime.Now;
                    order.CustomerId = user.CustomerId;
                    //order.LineItem.Add(); TO DO NOW

                    Console.WriteLine("Enter shipping address:");
                    string address = Console.ReadLine();
                    order.Address = address;
                    Console.WriteLine($"Time of order:{order.OrderTime}");









                    /*
                    The customer should be able to place orders
                    The customer should be able to view their order history
                    The customer should be able to view location inventory
                    The customer should know how much of a product is remaining
                    The customer should be able to purchase multiple products
                    */

                }

            } while (!isValidMenuItem || !userInput.Equals("x"));

        }

        public void PrintCustomerMenuOptions()
        {
            Console.WriteLine("[0] Adopt A Plant");                 //shop by plant
            Console.WriteLine("[1] Find A Plant");                  //shop by inventory at a location
            Console.WriteLine("[2] Find the right plant for you");  //personality quiz
            Console.WriteLine("[3] View Order History");
            Console.WriteLine("[4] About Us");
            Console.WriteLine("[x] Exit");                          //remove product

            userInput = Console.ReadLine();
        }

    }

}