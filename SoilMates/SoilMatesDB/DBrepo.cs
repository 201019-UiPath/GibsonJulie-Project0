using System.Reflection;
using System.Linq.Expressions;
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
            //if product location combination exists just update quantity

            Console.WriteLine("Duplicate Inventory item, increasing quanity");
            Inventory item = GetInventoryItem(inventory.ProductForeingId, inventory.LocationForeignId);
            if (item == null)
            {
                //item not in inventory 
                context.Inventories.Add(inventory);
            }
            else
            {
                Console.WriteLine("Increased item quantity");
                //increase quantity in inventory
                item.Quantity++;
            }
            //context.Inventories.Add(inventory);
            //context.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            //context.SaveChanges();

            if (!context.Locations.Any())
            {
                //product table is empty
                context.Locations.Add(location);
            }
            else
            {
                Location isDuplicate = GetLocationByName(location.Name);
                if (isDuplicate == null)
                {
                    context.Locations.Add(location);
                }
                else
                {
                    //if store name exists, check to see if if has the same address if so location is duplicate and not added 
                    if (isDuplicate.Address == location.Address)
                    {
                        Console.WriteLine("Location is a duplicate");
                    }
                    else
                    {
                        context.Locations.Add(location);
                    }

                }
            }
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
            //context.Products.Add(product);
            //context.SaveChanges();

            if (!context.Products.Any())
            {
                //product table is empty
                context.Products.Add(product);
            }
            else
            {
                Product isDuplicate = GetProduct(product.Name);
                if (isDuplicate == null)
                {
                    context.Products.Add(product);
                }
                else
                {
                    Console.WriteLine("Product is duplicate");
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return context.Customers.Include(customer => customer).ToList();
        }

        public List<Inventory> GetAllInventory()
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        public Inventory GetInventoryItem(int productId, int locationId)
        {
            return (Inventory)context.Inventories.FirstOrDefault(x => x.ProductForeingId == productId && x.LocationForeignId == locationId);
        }


        public List<Location> GetAllLocations()
        {
            return context.Locations.Include(s => s.StoreProducts).ToList();
        }

        public List<Manager> GetAllManagers()
        {
            return context.Managers.Include(s => s).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders.Include(s => s).ToList();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProduct(string name)
        {
            return (Product)context.Products.FirstOrDefault(x => x.Name == name);
        }

        public Product GetProduct(int id)
        {
            return (Product)context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public Customer GetCustomer(int id)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Id == id);
        }

        public Customer GetCustomer(string name)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Name == name);
        }

        public Location GetLocationByName(string name)
        {
            return (Location)context.Locations.FirstOrDefault(x => x.Name == name);
        }

        public Location GetLocationByLocation(string address)
        {
            return (Location)context.Locations.FirstOrDefault(x => x.Address == address);
        }


        public List<Inventory> GetInventoryItemByProductId(int id)
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();
        }

        public List<Inventory> GetInventoryItemByLocationId(int id)
        {
            return context.Inventories.Include(inventory => inventory.Product).Include(inventory => inventory.Location).ToList();

        }


        public Customer GetCustomerByLogin(string password, string email)
        {
            return (Customer)context.Customers.FirstOrDefault(x => x.Password == password && x.Email == email);
        }

        public Location GetLocationById(int id)
        {
            return (Location)context.Locations.Include(x => x.StoreProducts).ThenInclude(x => x.Product).FirstOrDefault();
        }

        public Manager GetManagerById(int id)
        {
            return (Manager)context.Managers.FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrderById(int id)
        {
            return (Order)context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public Product GetProductByName(string name)
        {
            return (Product)context.Products.FirstOrDefault(x => x.Name == name);
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