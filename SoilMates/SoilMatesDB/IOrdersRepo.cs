using System.Threading.Tasks;
using System.Collections.Generic;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    public interface IOrdersRepo
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();

        List<Order> GetOrderByCustomerId(int id);

    }
}