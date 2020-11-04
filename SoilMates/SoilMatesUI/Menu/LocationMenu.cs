using System;
using SoilMatesBL;
using SoilMatesDB.Models;
using SoilMatesDB;
using SoilMatesLib;
using Serilog;

namespace SoilMatesUI.Menu
{
    public class LocationMenu : IMenu
    {
        ManagerService managerService;
        ProductService productService;
        LocationService locationService;
        InventoryService inventoryService;
        OrderService orderService;
        IRepository repo;
        private IMenuBL menuBL = new MenuBL();

        public LocationMenu(IRepository repo)
        {
            this.repo = repo;
            this.managerService = new ManagerService(repo);
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
            this.orderService = new OrderService(repo);
        }

        public void Start()
        {
            string name, address;

            Console.WriteLine("Enter location name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter location address");
            address = Console.ReadLine();

            try
            {
                locationService.AddNewLocation(name, address);
            }
            catch (Exception ex)
            {
                Log.Warning("Attempted to add existing location.");
                Console.WriteLine(ex.Message);
                return;
            }
            locationService.SaveChanges();
            Console.WriteLine("New Location added! All locations listed below:");
            foreach (var location in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {location.LocationId} location name: {location.Name}");
            }

        }

        public void OrderAtLocation()
        {
            Console.WriteLine("Enter store id to print inventory:");
            foreach (var store in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {store.LocationId} \tlocations: {store.Name}  \tAddress: {store.Address}");
            }
            int storeId = Int32.Parse(Console.ReadLine());


            foreach (var order in orderService.GetOrderByLocatoinId(storeId))
            {
                Console.WriteLine($"\tOrder Id: {order.OrderId} Order Time: {order.OrderTime} Order Total Price: {order.TotalPrice}");
            }
            Console.WriteLine("All orders for location printed");
        }
    }
}