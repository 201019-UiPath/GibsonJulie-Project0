using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();

        Customer GetCustomer(string name);

        Customer GetCustomer(int id);

        void SaveChanges();

        Customer GetCustomerByLogin(string password, string email);

    }
}