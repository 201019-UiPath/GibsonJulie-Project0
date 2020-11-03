using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;
namespace SoilMatesDB
{
    /// <summary>
    /// Interface for product repo
    /// </summary>
    public interface IProductRepo
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();

        Product GetProduct(string name);

        Product GetProduct(int id);
        void RemoveProduct(Product product);

        void SaveChanges();
    }
}