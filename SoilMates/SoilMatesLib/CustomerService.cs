using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public interface ICustomerService
    {
        void AddCustomer(Customer newCustomer);
        List<Customer> GetAllCustomers();
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepo repo;

        public CustomerService(ICustomerRepo repo)
        {
            this.repo = repo;
        }

        public void AddCustomer(Customer newCustomer)
        {
            repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }
    }
}