using System.Collections.Generic;
using System;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer : User
    {
        public List<Orders> OrderHistory { get; set; }

    }
}