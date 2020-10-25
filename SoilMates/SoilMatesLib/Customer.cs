using System.Collections.Generic;

namespace SoilMatesLib
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer : User
    {
        int CustormerID { get; set; }
        public List<Orders> orderHistory = new List<Orders>();

        /// <summary>
        ///  Customer can place orders
        /// </summary>
        public void PlaceOrder()
        {

        }

        /// <summary>
        /// View order history
        /// </summary>
        public void ViewOrderHistory()
        {

        }

        /// <summary>
        ///  The customer should be able to purchase multiple products
        /// </summary>
        public void MakeOrder()
        {

        }

    }
}