namespace SoilMatesDB.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int Quantity { get; set; }

        public int ProductForeingId { get; set; }

        public Product Product { get; set; }

        public int LocationForeignId { get; set; }

        public Location Location { get; set; }

    }
}