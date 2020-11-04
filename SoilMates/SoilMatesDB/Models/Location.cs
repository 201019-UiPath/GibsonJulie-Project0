using System.Collections.Generic;
namespace SoilMatesDB.Models
{
    /// <summary>
    /// Location Model
    /// </summary>
    public class Location
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Inventory> StoreProducts { get; set; }

        public List<Order> orderHistory { get; set; }

        public Location() { }

        public Location(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

    }
}