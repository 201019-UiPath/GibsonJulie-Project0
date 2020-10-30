using System.Collections.Generic;
namespace SoilMatesDB.Models
{
    public class Manager : User
    {
        public List<Product> ProductList { get; set; }
    }
}