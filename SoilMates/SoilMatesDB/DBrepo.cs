using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SoilMatesDB.Models;
using Serilog;


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
            Log.Information("Added customer to repository.");
        }

        /// <summary>
        /// Retrieves list of customers in database
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            Log.Information("Retrieved all customers from repository.");
            return context.Customers.Include(customer => customer).ToList();
        }

        /// <summary>
        /// Retrieves customer from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomer(int id)
        {
            Log.Information("Retrieved customer from repository.");
            return (Customer)context.Customers.FirstOrDefault(x => x.Id == id);
        }


        /// <summary>
        /// Find customer by email informaion
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer GetCustomerByEmail(string email)
        {
            Log.Information("Retrieved customer from repository.");
            return (Customer)context.Customers.FirstOrDefault(x => x.Email.Equals(email));
        }

        public Manager GetManagerByEmail(string email)
        {
            Log.Information("Retrieved manager from repository.");
            return (Manager)context.Managers.FirstOrDefault(x => x.Email.Equals(email));
        }



        /// <summary>
        /// Retrieves customer from database by name of customer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetCustomer(string name)
        {
            Log.Information("Retrieved customer from repository.");
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
            Log.Information("Retrieved customer from repository.");
            return (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        /// <summary>
        /// Adds inventory model to database
        /// </summary>
        /// <param name="inventory"></param>
        public void AddInventory(Inventory inventory)
        {
            Log.Information("Added inventory item.");
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
            Log.Information("Retrieved inventory item.");
            return (Inventory)context.Inventories.FirstOrDefault(x => x.ProductForeingId == productId && x.LocationForeignId == locationId);
        }

        /// <summary>
        /// Retrieves list of all invetory objects from database
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            Log.Information("Retrieved all inventory items.");
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of invetory items from databse by porduct id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInventoryItemByProductId(int id)
        {
            Log.Information("Retrieved inventory list for product.");
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of inventory items from database by location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInventoryItemByLocationId(int id)
        {
            Log.Information("Retrieved list of inventory for location.");
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        /// <summary>
        /// Retrieves list of products from database by location id
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<Inventory> GetProductsByLocationId(Location location)
        {
            Log.Information("Retrieved inventory by location id.");
            return context.Inventories.Include(i => i.Location).Include(i => i.Product).Include(i => i.Quantity).ToList();
        }

        /// <summary>
        /// Retrieves list of inventory objects by product id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public List<Inventory> GetLocationsByProductId(Product product)
        {
            Log.Information("Retrieved inventory by product id.");
            return context.Inventories.Select(s => s).Where(x => x.Product.Description == product.Description).ToList();
        }

        /// <summary>
        /// Adds location to database
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Location location)
        {
            Log.Information("Added location to repository.");
            context.Locations.Add(location);
        }

        /// <summary>
        /// Returns all locations in database
        /// </summary>
        /// <returns></returns>
        public List<Location> GetAllLocations()
        {
            Log.Information("Retrieved all locations in repository.");
            return context.Locations.Include(s => s.StoreProducts).ToList();
        }

        /// <summary>
        /// returns all location by location id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetLocationById(int id)
        {
            Log.Information("Retrieved location by id.");
            return (Location)context.Locations.Include(x => x.StoreProducts).ThenInclude(x => x.Product).FirstOrDefault(x => x.LocationId == id);
        }

        /// <summary>
        /// Returns location by a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>location by id</returns>
        public Location GetLocationByName(string name)
        {
            Log.Information("Retrieved location by name.");
            return (Location)context.Locations.Include(x => x).FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Removes location by location 
        /// </summary>
        /// <param name="location"></param>
        public void RemoveLocation(Location location)
        {
            Log.Information("Removed location from locations in repository");
            context.Locations.Remove(location);
            SaveChanges();
        }

        /// <summary>
        /// Add order item OrderProduct to dataset OrderProducts 
        /// </summary>
        /// <param name="lineItem"></param>
        public void AddOrderProduct(OrderProduct lineItem)
        {
            Log.Information("Added line item to order.");
            context.OrderProducts.Add(lineItem);
        }

        /// <summary>
        /// Add manager to dataset Managers
        /// </summary>
        /// <param name="manager"></param>
        public void AddManager(Manager manager)
        {
            Log.Information("Added Manager.");
            context.Managers.Add(manager);
        }

        /// <summary>
        /// Add order to dataset Orders
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            Log.Information("Added order.");
            context.Orders.Add(order);
        }

        /// <summary>
        /// Add product to dataset Products
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Log.Information("Added Product.");
            context.Products.Add(product);
        }

        /// <summary>
        /// Get order item OrderProduct by orderid and productid
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns>Order product</returns>
        public OrderProduct GetOrderProduct(int orderId, int productId)
        {
            Log.Information("TPurchased item in order retrieved by order id.");
            return (OrderProduct)context.OrderProducts.FirstOrDefault(x => x.OrderForiegnId == orderId && x.ProductForiegnId == productId);
        }

        /// <summary>
        /// Returns list of all OrderProducts in dataset OrderProducts
        /// </summary>
        /// <returns></returns>
        public List<OrderProduct> GetAllOrderProduct()
        {
            Log.Information("Retrieved all purchased items.");
            return context.OrderProducts.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all managers in Managers dataset
        /// </summary>
        /// <returns></returns>
        public List<Manager> GetAllManagers()
        {
            Log.Information("Retrieved all managers.");
            return context.Managers.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all orders in Orders dataset
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            Log.Information("Retrieved all orders.");
            return context.Orders.Include(s => s).ToList();
        }

        /// <summary>
        /// Returns list of all products in Products dataset 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            Log.Information("Retrieved all porducts in repository.");
            return context.Products.ToList();
        }

        /// <summary>
        /// Retrieves porduct by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetProduct(string name)
        {
            Log.Information("Retrieved product by name.");
            return (Product)context.Products.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Retrieves product from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            Log.Information("Retrieved product by id.");
            return (Product)context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        /// <summary>
        /// Retrieves manager from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Manager GetManagerById(int id)
        {
            Log.Information("Reterived manager by id.");
            return (Manager)context.Managers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns list of orders by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomerId(int id)
        {
            Log.Information("Retrieved order for customer.");
            return context.Orders.Include(s => s.LineItem).ThenInclude(s => s.Product).ToList();
        }

        /// <summary>
        /// Returns list of orders by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrderByLocationId(int id)
        {
            Log.Information("Retrieved order for location.");
            return context.Orders.Include(s => s.LineItem).ThenInclude(s => s.Product).ToList();
        }

        /// <summary>
        /// Retrieves product by product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetProductByName(string name)
        {
            Log.Information("Retrieved product by name.");
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
            Log.Information("Retrieved manager signed in.");
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
            Log.Information("Removed product.");
            context.Products.Remove(product);
            SaveChanges();
        }

        /// <summary>
        /// Removea inventory item from repository
        /// </summary>
        /// <param name="item"></param>
        public void RemoveInvetoryItem(Inventory item)
        {
            Log.Information("Removed inventory item.");
            context.Inventories.Remove(item);
            SaveChanges();
        }

        /// <summary>
        /// Removes manager from repository
        /// </summary>
        /// <param name="manager"></param>
        public void RemoveManager(Manager manager)
        {
            Log.Information("Removed manager.");
            context.Managers.Remove(manager);
            SaveChanges();
        }

    }
}