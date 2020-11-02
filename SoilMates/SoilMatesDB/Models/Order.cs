using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Order model
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public int LocationId { get; set; }
        public string Address { get; set; }
        public DateTime OrderTime { get; set; }
        public Decimal TotalPrice { get; set; }
        public List<OrderProduct> LineItem { get; set; }

    }
}