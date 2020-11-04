using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;
using Serilog;
using System;

namespace SoilMatesLib
{

    /// <summary>
    /// Service that connects Customer to repository
    /// </summary>
    public class CustomerService
    {
        private ICustomerRepo repo;

        /// <summary>
        /// Customer service constructor with ICustomerRepo injection
        /// </summary>
        /// <param name="repo"></param>
        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds customer
        /// </summary>
        /// <param name="newCustomer"></param>
        public void AddCustomer(Customer newCustomer)
        {
            repo.AddCustomer(newCustomer);  //TODO: check for duplicate customers
            Log.Information("New customer signed up.");
        }

        /// <summary>
        /// Returns list of all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }

        /// <summary>
        /// Save changes to repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }

        /// <summary>
        /// Get customer by login infomation
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer GetCustomerByLogin(string password, string email)
        {
            return repo.GetCustomerByLogin(password, email);
        }

        public void SignUpCustomer(string name, string email, string password)
        {
            if (repo.GetCustomerByEmail(email) != null)
            {
                Log.Warning("Existing user attempted new sign up.");
                throw new Exception("Customer already exists!");
            }
            Customer newCustomer = new Customer(name, email, password);
            AddCustomer(newCustomer);
            SaveChanges();
        }


    }
}