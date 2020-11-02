namespace SoilMatesDB.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderForiegnId { get; set; }
        public int ProductForiegnId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}