using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Runtime.CompilerServices;
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
        }

        public List<Customer> GetAllCustomers()
        {
            return repo.GetAllCustomers();
        }
    }
}