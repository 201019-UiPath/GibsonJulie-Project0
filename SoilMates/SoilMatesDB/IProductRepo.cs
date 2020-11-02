using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;
namespace SoilMatesDB
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();

        Product GetProduct(string name);

        Product GetProduct(int id);
        void RemoveProduct(Product product);
    }
}