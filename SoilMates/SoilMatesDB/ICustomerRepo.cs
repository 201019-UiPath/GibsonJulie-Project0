using System;
using SoilMatesDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoilMatesDB
{
    public interface ICustomerRepo
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();

        Customer GetCustomerByName(string name);

        Customer GetCustomerById(int id);


    }
}