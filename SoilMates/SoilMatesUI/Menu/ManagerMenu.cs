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
                    AddLocation();
                }

                if (isValidMenuItem && userInput.Equals("1"))
                {
                    AddPlantToStock();
                }

                if (isValidMenuItem && userInput.Equals("2"))
                {
                    AddPlantToStore();
                }

                if (isValidMenuItem && userInput.Equals("3"))
                {
                    printStoreInvetory();
                }

                if (isValidMenuItem && userInput.Equals("4"))
                {
                    PrintPlantInventory();
                }
            } while (!isValidMenuItem || !userInput.Equals("x"));
        }

        public void PrintManagerMenuOptions()
        {
            Console.WriteLine("[0] Add location"); //TODO possibly remove but managers can add locations for now
            Console.WriteLine("[1] Add plant to stock");
            Console.WriteLine("[2] Add plant to Store location");
            Console.WriteLine("[3] Print Store Inventory"); //Check products in store location
            Console.WriteLine("[4] Print Plant Inventory");  //Check product inventory by product type
            Console.WriteLine("[x] Exit"); //remove product
            userInput = Console.ReadLine();
        }

        public void AddLocation()
        {
            Location newLocation = new Location();
            Console.WriteLine("Enter location name: ");
            newLocation.Name = Console.ReadLine();

            Console.WriteLine("Enter location address");
            newLocation.Address = Console.ReadLine();

            locationService.AddLocation(newLocation);
            locationService.SaveChanges();

            Console.WriteLine("New Location added! All locations listed below:");
            foreach (var location in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
            }
        }

        public void AddPlantToStock()
        {
            Product newProduct = new Product();
            Console.WriteLine("Enter plant name: ");
            newProduct.Name = Console.ReadLine();
            Console.WriteLine("Add plant description: ");
            newProduct.Description = Console.ReadLine();
            Console.WriteLine("Add plant price:");
            newProduct.Price = Convert.ToDecimal(Console.ReadLine());
            productService.AddProduct(newProduct);
            productService.SaveChanges();

            Console.WriteLine("New plant added! All plants listed below:");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"\tProduct id: {product.ProductId} \tProduct name: {product.Name}");
            }
        }

        public void AddPlantToStore()
        {
            Console.WriteLine("Select a location by id to add from the following list:");
            foreach (var location in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
            }
            int idLocation = Int32.Parse(Console.ReadLine());
            Location locationProduct = locationService.GetLocationById(idLocation);
            Console.WriteLine(locationProduct.LocationId);

            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"\tProduct id: {product.ProductId} product name: {product.Name}");
            }

            Console.WriteLine("Select product to add to store from product list: ");
            int idProduct = Int32.Parse(Console.ReadLine());
            Product productLoaction = productService.GetProduct(idProduct);

            Inventory item = new Inventory(locationProduct, productLoaction, locationProduct.LocationId, productLoaction.ProductId);
            Console.WriteLine("Enter Quantity to be added: ");
            int quantity = Int32.Parse(Console.ReadLine());
            inventoryService.AddInventory(item);
            inventoryService.UpdateQuantity(item, quantity);
            inventoryService.SaveChanges();
        }
        public void PrintPlantInventory()
        {
            Console.WriteLine("Enter plant name to print inventory:");
            string plantName = Console.ReadLine();
            foreach (var plant in inventoryService.GetAllInventory())
            {
                if (plant.Product.Name == plantName)
                    Console.WriteLine($"\tName: {plant.Product.Name} \tLocation id: {plant.Location.Name} \tquantity: {plant.Quantity}");
            }
        }

        public void printStoreInvetory()
        {
            Console.WriteLine("Enter store id to print inventory:");
            foreach (var store in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {store.LocationId} \tlocations: {store.Name}  \tAddress: {store.Address}");
            }
            int storeId = Int32.Parse(Console.ReadLine());


            foreach (var plant in inventoryService.GetInvetoryItemByLocationId(storeId))
            {
                if (plant.Location.LocationId == storeId)
                    Console.WriteLine($"\tLocation id: {plant.Location.LocationId} \tquantity: {plant.Quantity}\tName: {plant.Product.Name} ");
            }
        }


    }
}
