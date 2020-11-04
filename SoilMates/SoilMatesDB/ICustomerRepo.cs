using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    /// <summary>
    /// Interface for customer repository
    /// </summary>
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();

        Customer GetCustomer(string name);

        Customer GetCustomer(int id);

        void SaveChanges();

        Customer GetCustomerByLogin(string password, string email);

        Customer GetCustomerByEmail(string email);

    }
}