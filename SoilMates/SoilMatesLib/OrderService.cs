using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public class OrderService
    {
        private IOrdersRepo repo;

        public OrderService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return repo.GetAllOrders();
        }

        public List<Order> GetOrderByCustomerId(int orderId)
        {
            return repo.GetOrderByCustomerId(orderId);
        }

        public void SubmitOrder(Order newOrder, int customerId, int storeId, decimal totalPrice)
        {
            newOrder.OrderTime = DateTime.Now;
            newOrder.CustomerId = customerId;
            newOrder.LocationId = storeId;
            newOrder.TotalPrice = totalPrice;
        }

        public void SaveChanges()
        {
            repo.SaveChanges();
        }

    }
}