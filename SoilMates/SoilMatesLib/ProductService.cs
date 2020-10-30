using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public class ProductService
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

        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }


    }
}