using System;
using SoilMatesBL;
using SoilMatesDB;

namespace SoilMatesUI.Menu
{
    public class CustomerMenu : IMenu
    {
        private string userInput;
        private SignupMenu _signupMenu;
        private LoginMenu _loginMenu;
        private CustomerMenu customerMenu;
        private string SignInOption { get; set; }
        private IMenuBL menuBL = new MenuBL();

        public void Start()
        {
            throw new NotImplementedException();
        }

    }
}