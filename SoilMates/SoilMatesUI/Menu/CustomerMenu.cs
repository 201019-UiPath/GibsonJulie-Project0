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
        ProductService productService;
        LocationService locationService;
        InventoryService inventoryService;
        OrderService orderService;
        IRepository repo;
        OrderProductService orderProductService;
        private string userInput;
        private IMenuBL menuBL = new MenuBL();

        /// <summary>
        /// Customer menu constructor
        /// </summary>
        /// <param name="repo"></param>
        public CustomerMenu(IRepository repo)
        {
            this.repo = repo;
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
            this.orderService = new OrderService(repo);
            this.orderProductService = new OrderProductService(repo);
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
                    OrderPlant(user);
                }

                if (isValidMenuItem && userInput.Equals("1"))
                {
                    GetOrderHistory(user);

                }
                if (isValidMenuItem && userInput.Equals("2"))
                {
                    GetLocationInventory();
                }
            } while (!isValidMenuItem || !userInput.Equals("x"));
        }


        /// <summary>
        /// Gets user details to retrieve order history based on price or time of order
        /// </summary>
        /// <param name="user"></param>
        public void GetOrderHistory(User user)
        {
            Console.WriteLine("Order history by: \n[0] Date (Most recent) \n[1] Price (lowest to highest) "); // TODO

            string orderBy = Console.ReadLine();
            List<Order> _orders = orderService.GetOrderByCustomerId(user.Id);
            if (orderBy.Equals("0"))
            {
                _orders.Sort((x, y) => DateTime.Compare(y.OrderTime, x.OrderTime));
                foreach (var myOrder in _orders)
                {
                    Console.WriteLine($"Time of Order: {myOrder.OrderTime}  Total Purchase Price: {myOrder.TotalPrice}");
                    foreach (var _product in myOrder.LineItem)
                    {
                        Console.WriteLine($"\tProduct Id: {_product.Product.ProductId} \tProduct Name: {_product.Product.Name} \tProduct Price: {_product.Product.Price}");
                    }
                }
            }

            if (orderBy.Equals("1"))
            {
                _orders.Sort((x, y) => Decimal.Compare(x.TotalPrice, y.TotalPrice));
                foreach (var myOrder in _orders)
                {
                    Console.WriteLine($"Time of Order: {myOrder.OrderTime}  Total Purchase Price: {myOrder.TotalPrice}");
                    foreach (var _product in myOrder.LineItem)
                    {
                        Console.WriteLine($"\tProduct Id: {_product.Product.ProductId} \tProduct Name: {_product.Product.Name} \tProduct Price: {_product.Product.Price}");
                    }
                }
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

            foreach (var plant in inventoryService.GetInvetoryItemByLocationId(storeId))
            {
                if (plant.Location.LocationId == storeId)
                    Console.WriteLine($"\tLocation id: {plant.Location.LocationId} \tquantity: {plant.Quantity}\tName: {plant.Product.Name} ");
            }
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

        /// <summary>
        /// Order plant from store 
        /// </summary>
        /// <param name="user"></param>
        public void OrderPlant(Customer user)
        {
            Decimal totalPrice = 0;
            Console.WriteLine("Select the store to shop from by id:");
            foreach (var store in locationService.GetAllLocations())
            {
                Console.WriteLine($"\tlocation id: {store.LocationId} \tlocations: {store.Name}  \tAddress: {store.Address}");
            }
            int storeID = Int32.Parse(Console.ReadLine());

            Location customerLocation = locationService.GetLocationById(storeID);
            List<Inventory> customerInventory = customerLocation.StoreProducts;

            Order newOrder = new Order();
            string input;
            do
            {
                Console.WriteLine("Select a product by id");
                foreach (var invetoryItem in customerInventory)
                {
                    if (invetoryItem.Quantity > 0)
                    {
                        Console.WriteLine($"\tproduct id: {invetoryItem.ProductForeingId} \tProduct name: {invetoryItem.Product.Name}  \tquantity: {invetoryItem.Quantity}");
                    }
                }
                int productId = Int32.Parse(Console.ReadLine());
                Product soldProduct = productService.GetProduct(productId);

                Console.WriteLine("Type quantity of item to purchase:");
                int amountItem = Int32.Parse(Console.ReadLine());

                Inventory updateInventoryItem = inventoryService.GetInventoryItem(productId, storeID);
                try
                {
                    inventoryService.SoldInventoryUpdate(updateInventoryItem, amountItem);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    input = "c"; //user input to continue shopping
                    continue;
                }
                totalPrice += (amountItem * soldProduct.Price);
                OrderProduct itemInCart = new OrderProduct();
                orderProductService.UpdateOrderProductInCart(itemInCart, soldProduct, newOrder);
                orderProductService.AddOrderProduct(itemInCart);
                newOrder.LineItem.Add(itemInCart);

                Console.WriteLine("Press any key to continue shopping (type [x] to finish order)");
                input = Console.ReadLine();

            } while (!input.Equals("x"));

            orderService.SubmitOrder(newOrder, user.Id, storeID, totalPrice);
            Console.WriteLine("Enter shipping address:");
            string address = Console.ReadLine();
            newOrder.Address = address;
            orderService.SaveChanges();
        }
    }
}