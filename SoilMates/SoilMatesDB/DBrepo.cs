using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SoilMatesDB.Models;
using System;

namespace SoilMatesDB
{
    /// <summary>
    /// Database repository for soilmates
    /// </summary>
    public class DBrepo : ICustomerRepo, ILocationRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IManagerRepo, IRepository, IOrderProduct
    {
        /// <summary>
        /// Defines database context
        /// </summary>
        private SoilMatesContext context;

        /// <summary>
        /// Repository constructor
        /// </summary>
        /// <param name="context"></param>
        public DBrepo(SoilMatesContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds customer to Customers dataset
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        /// <summary>
        /// Retrieves list of customers in database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return context.Customers.Include(customer => customer).ToList();
        }

        /// <summary>
        /// Retrieves customer from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Retrieves customer from database by name of customer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomer(string name)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Retrieves customer by email and password combination
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer GetCustomerByLogin(string password, string email)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        /// <summary>
        /// Adds inventory model to database
        /// </summary>
        /// <param name="inventory"></param>
        public void AddInventory(Inventory inventory)
        {
            context.Inventories.Add(inventory);
        }

        /// <summary>
        /// Retrieves inventory object from database by product id and location id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Inventory GetInventoryItem(int productId, int locationId)
        {
            return (Inventory)context.Inventories.FirstOrDefault(x => x.ProductForeingId == productId && x.LocationForeignId == locationId);
        }

        /// <summary>
        /// Retrieves list of all invetory objects from database
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of invetory items from databse by porduct id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInventoryItemByProductId(int id)
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of inventory items from database by location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInventoryItemByLocationId(int id)
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of products from database by location id
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<Inventory> GetProductsByLocationId(Location location)
        {
            return context.Inventories.Include(i => i.Location).Include(i => i.Product).Include(i => i.Quantity).ToList();
        }

        /// <summary>
        /// Retrieves list of inventory objects by product id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public List<Inventory> GetLocationsByProductId(Product product)
        {
            return context.Inventories.Select(s => s).Where(x => x.Product.Description == product.Description).ToList();
        }

        /// <summary>
        /// Adds location to database
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
        }

        /// <summary>
        /// Returns all locations in database
        /// </summary>
        /// <returns></returns>
        public List<Location> GetAllLocations()
        {
            return context.Locations.Include(s => s.StoreProducts).ToList();
        }

        /// <summary>
        /// returns all location by location id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetLocationById(int id)
        {
            return (Location)context.Locations.Include(x => x.StoreProducts).ThenInclude(x => x.Product).FirstOrDefault(x => x.LocationId == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Location GetLocationByName(string name)
        {
            return (Location)context.Locations.Include(x => x).FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Removes location by location 
        /// </summary>
        /// <param name="location"></param>
        public void RemoveLocation(Location location)
        {
            context.Locations.Remove(location);
            SaveChanges();
        }

        /// <summary>
        /// Add order item OrderProduct to dataset OrderProducts 
        /// </summary>
        /// <param name="lineItem"></param>
        public void AddOrderProduct(OrderProduct lineItem)
        {
            context.OrderProducts.Add(lineItem);
        }

        /// <summary>
        /// Add manager to dataset Managers
        /// </summary>
        /// <param name="manager"></param>
        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
        }

        /// <summary>
        /// Add order to dataset Orders
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        /// <summary>
        /// Add product to dataset Products
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        /// <summary>
        /// Get order item OrderProduct by orderid and productid
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public OrderProduct GetOrderProduct(int orderId, int productId)
        {
            return (OrderProduct)context.OrderProducts.FirstOrDefault(x => x.OrderForiegnId == orderId && x.ProductForiegnId == productId);
        }

        /// <summary>
        /// Returns list of all OrderProducts in dataset OrderProducts
        /// </summary>
        /// <returns></returns>
        public List<OrderProduct> GetAllOrderProduct()
        {
            return context.OrderProducts.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all managers in Managers dataset
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetAllManagers()
        {
            return context.Managers.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all orders in Orders dataset
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            return context.Orders.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all products in Products dataset 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        /// <summary>
        /// Retrieves porduct by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetProduct(string name)
        {
            return (Product)context.Products.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Retrieves product from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            return (Product)context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        /// <summary>
        /// Retrieves manager from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Manager GetManagerById(int id)
        {
            return (Manager)context.Managers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns list of orders by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomerId(int id)
        {

            return context.Orders.Include(s => s.LineItem).ThenInclude(s => s.Product).ToList();
        }

        /// <summary>
        /// Retrieves product by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetProductByName(string name)
        {
            return (Product)context.Products.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Returns manager with matching password and email
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Manager GetManagerByLogin(string password, string email)
        {
            return (Manager)context.Managers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        /// <summary>
        /// Save changes to repository
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Removes product from repository
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            context.Products.Remove(product);
            SaveChanges();
        }

        /// <summary>
        /// Removea inventory item from repository
        /// </summary>
        /// <param name="item"></param>
        public void RemoveInvetoryItem(Inventory item)
        {
            context.Inventories.Remove(item);
            SaveChanges();
        }

        /// <summary>
        /// Removes manager from repository
        /// </summary>
        /// <param name="manager"></param>
        public void RemoveManager(Manager manager)
        {
            context.Managers.Remove(manager);
            SaveChanges();
        }

    }
}