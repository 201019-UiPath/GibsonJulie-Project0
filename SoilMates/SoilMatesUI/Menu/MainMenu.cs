using System;
using SoilMatesBL;
using SoilMatesDB;

namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Menu Interface for users of soilMates console application 
    /// </summary>
    public class MainMenu : IMenu
    {
        private string userInput;
        private SignupMenu _signupMenu;
        private LoginMenu _loginMenu;
        private IMenuBL menuBL = new MenuBL();
        private IRepository repository;
        public MainMenu(SoilMatesContext context)
        {
            repository = new DBrepo(context);
            this._loginMenu = new LoginMenu(repository);
            this._signupMenu = new SignupMenu(repository);
        }

        public void Start()
        {
            Console.WriteLine("Welcome to SoilMates!");

            bool isValidInput;
            do
            {
                Console.WriteLine("Please select a sign in option:");
                Console.WriteLine("[0] SignUp");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[x] Exit");
                userInput = Console.ReadLine();
                isValidInput = menuBL.SignInInputValidation(userInput);  //TODO 

                switch (userInput)
                {
                    case "0":
                        this._signupMenu.Start();
                        break;
                    case "1":
                        this._loginMenu.Start();
                        break;
                    default:
                        return;
                }
            } while (!isValidInput || !userInput.Equals("x"));
        }
    }
}

