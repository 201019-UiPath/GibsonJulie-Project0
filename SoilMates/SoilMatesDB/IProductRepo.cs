using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;
namespace SoilMatesDB
{
    public interface IProductRepo
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();

        Product GetProductByName(string name);

        void DeleteProduct(Product product);
        void RemoveProduct(Product product);
    }
}