using System;
using System.Collections.Generic;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Order model
    /// </summary>
    public class Orders
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Product> Purchases { get; set; }

    }
}