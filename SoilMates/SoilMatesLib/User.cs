namespace SoilMatesLib
{
    public abstract class User
    {
        int UserType { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }

        /// <summary>
        /// View location inventory
        /// </summary>
        public void SearchLocationProducts()
        {

        }

        /// <summary>
        /// View store inventory
        /// </summary>
        public void ViewStoreInventory()
        {

        }

        /// <summary>
        /// /// Search for product inventory
        /// </summary>
        public void ViewProductInventory()
        {

        }

    }
}