using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public class CustomerService
    {
        private ICustomerRepo repo;

        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public void AddCustomer(Customer newCustomer)
        {
            repo.AddCustomer(newCustomer);
            repo.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }

        public void SaveChanges()
        {
            repo.SaveChanges();
        }
    }
}