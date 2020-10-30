using System.Collections.Generic;
namespace SoilMatesDB.Models
{
    /// <summary>
    /// Location Model
    /// </summary>
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Inventory> StoreProducts { get; set; }
        //Location should have records of order history


    }
}