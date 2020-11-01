using System.Runtime.InteropServices;
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
        ManagerService managerService;
        ProductService productService;
        LocationService locationService;
        InventoryService inventoryService;
        IRepository repo;
        private string userInput;
        private IMenuBL menuBL = new MenuBL();

        public ManagerMenu(IRepository repo)
        {
            this.repo = repo;
            this.managerService = new ManagerService(repo);
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
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

                if (isValidMenuItem && userInput.Equals("0"))
                {
                    Location newLocation = new Location();
                    Console.WriteLine("Enter location name: ");
                    newLocation.Name = Console.ReadLine();

                    Console.WriteLine("Enter location address");
                    newLocation.Address = Console.ReadLine();

                    locationService.AddLocation(newLocation);
                    repo.SaveChanges();

                    Console.WriteLine("New Location added! All locations listed below:");
                    foreach (var location in locationService.GetAllLocations())
                    {
                        Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
                    }
                }

                if (isValidMenuItem && userInput.Equals("1"))
                {
                    Product newProduct = new Product();
                    Console.WriteLine("Enter plant name: ");
                    newProduct.Name = Console.ReadLine();
                    Console.WriteLine("Add plant description: ");
                    newProduct.Description = Console.ReadLine();
                    productService.AddProduct(newProduct);
                    repo.SaveChanges();

                    Console.WriteLine("New Location added! All locations listed below:");
                    foreach (var product in productService.GetAllProducts())
                    {
                        Console.WriteLine($"\tlocation id: {product.ProductId} location name: {product.Name}");
                    }
                }

                if (isValidMenuItem && userInput.Equals("2"))
                {
                    Console.WriteLine("Select a location by id to add from the following list:");
                    foreach (var location in locationService.GetAllLocations())
                    {
                        Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
                    }
                    int idLocation = Int32.Parse(Console.ReadLine());
                    Location locationProduct = locationService.GetLocationById(idLocation);

                    foreach (var product in productService.GetAllProducts())
                    {
                        Console.WriteLine($"\tProduct id: {product.ProductId} product name: {product.Name}");
                    }

                    Console.WriteLine("Select product to add to store from product list: ");
                    int idProduct = Int32.Parse(Console.ReadLine());
                    Product productLoaction = productService.GetProduct(idProduct);

                    Inventory item = new Inventory();
                    item.Location = locationProduct;
                    item.Product = productLoaction;
                    item.LocationForeignId = locationProduct.LocationId;
                    item.ProductForeingId = productLoaction.ProductId;

                    inventoryService.AddInventory(item);
                    productLoaction.ProductLocations.Add(item);
                    repo.SaveChanges();
                }

                if (isValidMenuItem && userInput.Equals("3"))
                {
                    Console.WriteLine("Enter store id to print inventory:");
                    int storeId = Int32.Parse(Console.ReadLine());
                    foreach (var plant in inventoryService.GetInvetoryItemByLocationId(storeId))
                    {
                        if (plant.Location.LocationId == storeId)
                            Console.WriteLine($"\tName: {plant.Product.Name} \t\tLocation id: {plant.Location.LocationId}");
                    }
                }

                if (isValidMenuItem && userInput.Equals("4"))
                {
                    Console.WriteLine("Enter plant name to print inventory:");
                    string plantName = Console.ReadLine();
                    foreach (var plant in inventoryService.GetAllInventory())
                    {
                        if (plant.Product.Name == plantName)
                            Console.WriteLine($"\tName: {plant.Product.Name} \t\tLocation id: {plant.Location.Name}");
                    }

                }
            } while (!isValidMenuItem || !userInput.Equals("x"));
        }

        public void PrintManagerMenuOptions()
        {
            Console.WriteLine("[0] Add location"); //TODO possibly remove but managers can add locations for now
            Console.WriteLine("[1] Add plant");
            Console.WriteLine("[2] Add plant to Store location");
            Console.WriteLine("[3] Print Store Inventory"); //Check products in store location
            Console.WriteLine("[4] Print Plant Inventory");  //Check product inventory by product type
            // Console.WriteLine("[2] Add Product to Inventory"); //add new product
            // Console.WriteLine("[3] Remove Product from inventory"); //remove product
            Console.WriteLine("[x] Exit"); //remove product
            userInput = Console.ReadLine();
        }

    }
}
