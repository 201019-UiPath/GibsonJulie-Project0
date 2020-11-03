namespace SoilMatesDB.Models
{
    /// <summary>
    /// Inventory class connects products to locations
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Inventory is initialized to 1
        /// </summary>
        public Inventory()
        {
            Quantity = 1;
        }

        /// <summary>
        /// Parameterized Inventory constructor for adding new inventory item by the manager
        /// </summary>
        /// <param name="location"></param>
        /// <param name="product"></param>
        /// <param name="locationForeignId"></param>
        /// <param name="productForeingId"></param>
        public Inventory(Location location, Product product, int locationForeignId, int productForeingId)
        {
            Quantity = 1;
            Location = location;
            Product = product;
            LocationForeignId = locationForeignId;
            ProductForeingId = productForeingId;
        }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }

        public int ProductForeingId { get; set; }

        public Product Product { get; set; }

        public int LocationForeignId { get; set; }

        public Location Location { get; set; }

    }
}