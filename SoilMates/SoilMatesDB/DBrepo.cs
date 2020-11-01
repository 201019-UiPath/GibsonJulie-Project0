using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SoilMatesDB.Models;
using System;

namespace SoilMatesDB
{
    public class DBrepo : ICustomerRepo, ILocationRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IManagerRepo, IRepository
    {
        private SoilMatesContext context;

        public DBrepo(SoilMatesContext context)
        {
            this.context = context;
        }

        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine("Sign Up successfull!\n");
        }

        public void AddInventory(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            //context.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            //context.SaveChanges();
        }

        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            //context.SaveChanges();
            //Console.WriteLine("Sign up successfull!");
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            // context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            //context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return context.Customers.Select(x => x).Include("OrderHistory").ToList();
        }

        public List<Inventory> GetAllInventory()
        {
            return context.Inventories.Select(s => s).ToList();
        }


        public List<Location> GetAllLocations()
        {
            return context.Locations.Select(s => s).ToList();
        }

        public List<Manager> GetAllManagers()
        {
            return context.Managers.Select(s => s).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders.Select(s => s).ToList();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return (Customer)context.Customers.Where(x => x.Id == id);
        }

        public Customer GetCustomerByName(string name)
        {
            return (Customer)context.Customers.Where(x => x.Name == name);
        }

        public Location GetLocationByName(string name)
        {
            return (Location)context.Locations.Where(x => x.Name == name);
        }

        public Location GetLocationByLocation(string address)
        {
            return (Location)context.Locations.FirstOrDefault(x => x.Address == address);
        }


        public Inventory GetInventoryItemByProductId(int id)
        {
            return (Inventory)context.Inventories.FirstOrDefault(X => X.ProductForeingId == id);
        }

        public Inventory GetInventoryItemByLocationId(int id)
        {
            return (Inventory)context.Inventories.FirstOrDefault(X => X.LocationForeignId == id);
        }


        public Customer GetCustomerByLogin(string password, string email)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        public Location GetLocationById(int id)
        {
            return (Location)context.Locations.FirstOrDefault(x => x.LocationId == id);
        }

        public Manager GetManagerById(int id)
        {
            return (Manager)context.Managers.Where(x => x.Id == id);
        }

        public Order GetOrderById(int id)
        {
            return (Order)context.Orders.Where(x => x.OrderId == id);
        }

        public Product GetProductByName(string name)
        {
            return (Product)context.Products.Where(x => x.Name == name);
        }

        public Manager GetManagerByLogin(string password, string email)
        {
            return (Manager)context.Managers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        public List<Inventory> GetAllInInventory()
        {
            return context.Inventories.Select(s => s).ToList();
        }

        public List<Inventory> GetProductsByLocationId(Location location)
        {
            return context.Inventories.Select(s => s).Where(x => x.Location.Name == location.Name).ToList();
        }

        public List<Inventory> GetLocationsByProductId(Product product)
        {
            return context.Inventories.Select(s => s).Where(x => x.Product.Description == product.Description).ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            SaveChanges();
        }

        public void RemoveLocation(Location location)
        {
            context.Locations.Remove(location);
            SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            context.Products.Remove(product);
            SaveChanges();
        }

        public void RemoveInvetoryItem(Inventory item)
        {
            context.Inventories.Remove(item);
            SaveChanges();
        }

        public void RemoveManager(Manager manager)
        {
            context.Managers.Remove(manager);
            SaveChanges();
        }
    }
}