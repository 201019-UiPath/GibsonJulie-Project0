using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();

        Customer GetCustomerByName(string name);

        Customer GetCustomerById(int id);

        Customer GetCustomerByLogin(string password, string email);

    }
}