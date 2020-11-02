namespace SoilMatesDB.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Quantity = 1;
        }

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