using System.Collections.Generic;

namespace SoilMatesDB.Models
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Inventory> ProductLocations { get; set; }

        public override string ToString()
        {
            return "Product Id: " + this.Id + " Product Description: " + this.Description;
        }
    }
}