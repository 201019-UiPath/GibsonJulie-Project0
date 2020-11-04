using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;
using Serilog;

namespace SoilMatesUI.Menu
{
    public class InventoryMenu : IMenu
    {
        ProductService productService;
        LocationService locationService;
        InventoryService inventoryService;
        IRepository repo;

        public InventoryMenu(IRepository repo)
        {
            this.repo = repo;
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
        }

        /// <summary>
        /// Inventory menu start 
        /// </summary>
        public void Start() { }

        /// <summary>
        /// Adds plant to inventory
        /// </summary>
        public void AddPlantToInventory()
        {
            Console.WriteLine("Select a location from the following by id to add a plant to inventory:");
            foreach (var location in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
            }
            int idLocation = Int32.Parse(Console.ReadLine());
            Location _location = locationService.GetLocationById(idLocation);

            Console.WriteLine("Select product by id from list to add to store inventory: ");
            foreach (var product in productService.GetAllProducts())
            {
                Console.WriteLine($"\tProduct id: {product.ProductId} product name: {product.Name}");
            }
            int idProduct = Int32.Parse(Console.ReadLine());
            Product _product = productService.GetProduct(idProduct);

            Console.WriteLine("Enter Quantity to be added: ");
            int quantity = Int32.Parse(Console.ReadLine());

            inventoryService.AddItemToInventory(_location, _product, quantity);

        }

        /// <summary>
        /// Prints plant inventory
        /// </summary>
        public void PrintPlantInventory()
        {
            Console.WriteLine("Enter plant name to print inventory:");
            string plantName = Console.ReadLine();
            foreach (var plant in inventoryService.GetAllInventory())
            {
                if (plant == null)
                {
                    Console.WriteLine("Out of stock currently!");
                    Log.Information($"{plant.Product.Name} is out of stock");
                }
                if (plant.Product.Name == plantName)
                    Console.WriteLine($"\tName: {plant.Product.Name} \tLocation id: {plant.Location.Name} \tquantity: {plant.Quantity}");
            }
        }

        /// <summary>
        /// Print store inventory
        /// </summary>
        public void PrintStoreInvetory()
        {
            Console.WriteLine("Enter store id to print inventory:");
            foreach (var store in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {store.LocationId} \tlocations: {store.Name}  \tAddress: {store.Address}");
            }
            int storeId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Products at selected location:");
            foreach (var plant in inventoryService.GetInvetoryItemByLocationId(storeId))
            {
                if (plant.Location.LocationId == storeId)
                    Console.WriteLine($"\tquantity: {plant.Quantity}\tName: {plant.Product.Name} ");
            }
        }

        /// <summary>
        ///  Prints location inventory given location id
        /// </summary>
        /// <param name="user"></param>
        public void GetLocationInventory()
        {
            Console.WriteLine("Enter store id to print inventory:");
            foreach (var store in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {store.LocationId} \tlocations: {store.Name}  \tAddress: {store.Address}");
            }
            int storeId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Products in inventory:");

            foreach (var plant in inventoryService.GetInvetoryItemByLocationId(storeId))
            {

                if (plant.Location.LocationId == storeId)
                    Console.WriteLine($"\tName: {plant.Product.Name} \tquantity: {plant.Quantity} ");
            }
            Console.WriteLine("All products inventory printed\n");
        }
    }
}