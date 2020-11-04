using System.Dynamic;
using System.Collections.Generic;
using System;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Customer Model inherits from user
    /// </summary>
    public class Customer : User
    {
        public Customer()
        {
            UserType = 0;
        }

        public Customer(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.UserType = 0;
        }


    }
}