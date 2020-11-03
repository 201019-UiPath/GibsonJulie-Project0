using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    /// <summary>
    /// Line items in orders allowing for multiple porducts per order
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


        /// <summary>
        /// Updates items in that customer selects to buy
        /// </summary>
        /// <param name="itemInCart"></param>
        /// <param name="soldProduct"></param>
        /// <param name="newOrder"></param>
        public void UpdateOrderProductInCart(OrderProduct itemInCart, Product soldProduct, Order newOrder)
        {
            itemInCart.OrderForiegnId = newOrder.OrderId;
            itemInCart.Product = soldProduct;
            itemInCart.ProductForiegnId = soldProduct.ProductId;
            itemInCart.Order = newOrder;
        }
    }
}