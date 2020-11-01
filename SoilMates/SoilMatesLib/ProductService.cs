using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public interface IProductService
    {
        void AddProduct(Product newProduct);
        List<Product> GetAllProducts();

        void RemoveProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public void AddProduct(Product newProduct)
        {
            repo.AddProduct(newProduct);
        }

        public Product GetProduct(string name)
        {
            return repo.GetProduct(name);
        }


        public Product GetProduct(int id)
        {
            return repo.GetProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        //remove product 
        public void RemoveProduct(Product product)
        {
            repo.RemoveProduct(product);
        }



    }
}