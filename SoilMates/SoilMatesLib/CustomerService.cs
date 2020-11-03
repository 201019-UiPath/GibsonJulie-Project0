using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

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
    }
}