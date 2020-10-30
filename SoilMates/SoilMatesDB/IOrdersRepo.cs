using System.Threading.Tasks;
using System.Collections.Generic;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    public interface IOrdersRepo
    {
        void AddOrder(Orders order);
        List<Orders> GetAllOrders();

        Orders GetOrderById(int id);

    }
}