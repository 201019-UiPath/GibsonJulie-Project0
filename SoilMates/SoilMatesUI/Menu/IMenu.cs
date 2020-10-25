namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Main Menu for application
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Provides Welcome greeting and presents user with sign in option
        /// </summary>
        void Greeting();


        /// <summary>
        /// Store Menu items for customer
        /// </summary>
        void PrintCustomerMenuOptions();

        void SignUpMenu();

        /// <summary>
        ///  Menu for logging in current users
        /// </summary>
        void LoginMenu();

        /// <summary>
        /// Menu for Employee portal
        /// </summary>
        void PrintEmployeeMenu();

        /// <summary>
        /// Selects correct menu for type of user
        /// </summary>
        void SelectSignInMenu();

    }
}