using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;
using System;
using Serilog;

namespace SoilMatesLib
{
    /// <summary>
    /// Service for product models to interact with repository
    /// </summary>
    public class ProductService
    {
        private IProductRepo repo;

        /// <summary>
        /// Product service constructor accepts IProductRepo injection for repository
        /// </summary>
        /// <param name="repo"></param>
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }


        /// <summary>
        /// Service adds a product to repository 
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            repo.AddProduct(product);
        }

        /// <summary>
        /// Adds product given user input
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        public void AddNewProduct(string name, decimal price, string description)
        {
            Product product = new Product(name, price, description);
            if (GetAllProducts().Count == 0)
            {

                AddProduct(product);
            }
            else
            {
                Product isDuplicate = GetProduct(product.Name);
                if (isDuplicate == null)
                {
                    AddProduct(product);
                }
                else
                {
                    Log.Warning("Attempted to add duplicate product.");
                    throw new Exception("Product already exists, cannot be added!");
                }
            }
        }

        /// <summary>
        /// Gets product from repository by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Product GetProduct(string name)
        {
            return repo.GetProduct(name);
        }


        /// <summary>
        /// Retrieves product from repostory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            return repo.GetProduct(id);
        }

        /// <summary>
        /// Retrieves list of products from repository
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        /// <summary>
        /// Removes a product from repository
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            repo.RemoveProduct(product);
        }

        /// <summary>
        /// Saves changes to repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }

    }
}