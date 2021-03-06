using System;
using SoilMatesBL;
using SoilMatesDB;
using Serilog;

namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Menu for users of soilMates console application, implements IMenu
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

        /// <summary>
        /// entry point for main menu UI
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to SoilMates!");
            Log.Verbose("Main Menu started.");

            bool isValidInput;
            do
            {
                Console.WriteLine("Please select a sign in option:");
                Console.WriteLine("[0] SignUp");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[x] Exit");
                userInput = Console.ReadLine();
                isValidInput = menuBL.SignInInputValidation(userInput);

                switch (userInput)
                {
                    case "0":
                        this._signupMenu.Start();
                        break;
                    case "1":
                        this._loginMenu.Start();
                        break;
                }
            } while (!isValidInput || !userInput.Equals("x"));
        }
    }
}

