using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    /// <summary>
    /// Line items in orders allowing for multiple orders per product
    /// </summary>
    public class OrderProductService
    {
        private IOrderProduct repo;

        public OrderProductService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds a line item to OrderProduct table
        /// </summary>
        /// <param name="orderProduct"></param>
        public void AddOrderProduct(OrderProduct orderProduct)
        {
            repo.AddOrderProduct(orderProduct);
        }

        /// <summary>
        /// Gets line item given order id and product id
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public OrderProduct GetOrderProduct(int orderId, int productId)
        {
            return repo.GetOrderProduct(orderId, productId);
        }

        /// <summary>
        /// Returns all line item (all purchased items)
        /// </summary>
        /// <returns></returns>
        public List<OrderProduct> GetAllOrderProduct()
        {
            return repo.GetAllOrderProduct();
        }


    }
}