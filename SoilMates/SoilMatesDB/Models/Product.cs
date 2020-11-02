using System.Collections.Generic;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public List<Inventory> ProductLocations { get; set; }
        public List<OrderProduct> LineItem { get; set; }

    }
}