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

        OrderService orderService;
        IRepository repo;

        OrderProductService orderProductService;


        private string userInput;
        private IMenuBL menuBL = new MenuBL();

        public CustomerMenu(IRepository repo)
        {
            this.repo = repo;
            this.productService = new ProductService(repo);
            this.locationService = new LocationService(repo);
            this.inventoryService = new InventoryService(repo);
            this.orderService = new OrderService(repo);
            this.orderProductService = new OrderProductService(repo);
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
                    OrderPlant(user);
                }

                if (isValidMenuItem && userInput.Equals("1"))
                {
                    //Console.WriteLine("Order history by price [0] or by date [1]"); // TODO
                    foreach (var allOrders in orderService.GetOrderByCustomerId(user.Id))
                    {
                        Console.WriteLine($"{allOrders.OrderId} {allOrders.OrderTime} ");
                    }
                }
            } while (!isValidMenuItem || !userInput.Equals("x"));

        }

        public void PrintCustomerMenuOptions()
        {

            Console.WriteLine("[0] Order A Plant");                 //shop by plant
            Console.WriteLine("[1] View Order History");                  //shop by inventory at a location
            Console.WriteLine("[2] View Location Inventory");
            Console.WriteLine("[x] Exit");                          //remove product

            userInput = Console.ReadLine();
        }

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
                totalPrice += soldProduct.Price;
                Inventory updateInventoryItem = inventoryService.GetInventoryItem(productId, storeID);
                updateInventoryItem.Quantity--;


                OrderProduct itemInCart = new OrderProduct();
                itemInCart.Product = soldProduct;
                itemInCart.ProductForiegnId = soldProduct.ProductId;
                itemInCart.Order = newOrder;
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