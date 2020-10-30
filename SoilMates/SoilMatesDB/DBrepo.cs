using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SoilMatesDB.Models;
using System;

namespace SoilMatesDB
{
    public class DBrepo : ICustomerRepo, ILocationRepo, IOrdersRepo, IProductRepo, IIventoryRepo, IManagerRepo
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

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
            Console.WriteLine("Sign up successfull!");
        }

        public void AddOrder(Orders order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
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

        public List<Orders> GetAllOrders()
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

        public Customer GetCustomerByLogin(string password, string email)
        {

            //var customer = (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
            return (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        public Location GetLocationById(int id)
        {
            return (Location)context.Locations.Where(x => x.Id == id);
        }

        public Manager GetManagerById(int id)
        {
            return (Manager)context.Managers.Where(x => x.Id == id);
        }

        public Orders GetOrderById(int id)
        {
            return (Orders)context.Orders.Where(x => x.Id == id);
        }

        public Product GetProductByName(string description)
        {
            return (Product)context.Products.Where(x => x.Description == description);
        }

        public Manager GetManagerByLogin(string password, string email)
        {
            return (Manager)context.Managers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }
    }
}