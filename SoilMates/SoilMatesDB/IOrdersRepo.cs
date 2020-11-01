using System.Threading.Tasks;
using System.Collections.Generic;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    public interface IOrdersRepo
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();

        Order GetOrderById(int id);

    }
}