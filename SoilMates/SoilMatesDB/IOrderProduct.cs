using System.Collections.Generic;
using SoilMatesDB.Models;
namespace SoilMatesDB
{
    public interface IOrderProduct
    {
        List<OrderProduct> GetAllOrderProduct();

        void AddOrderProduct(OrderProduct lineItem);

        OrderProduct GetOrderProduct(int orderId, int productId);
    }
}