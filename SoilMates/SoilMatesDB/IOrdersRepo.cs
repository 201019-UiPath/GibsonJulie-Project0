using System.Threading.Tasks;
using System.Collections.Generic;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    /// <summary>
    /// Interface for Orders repository
    /// </summary>
    public interface IOrdersRepo
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();

        List<Order> GetOrderByCustomerId(int id);

        List<Order> GetOrderByLocationId(int id);

        void SaveChanges();

    }
}