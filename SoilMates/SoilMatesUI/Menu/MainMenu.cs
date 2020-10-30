using System;
using SoilMatesBL;
using SoilMatesDB.Models;
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
        private CustomerMenu customerMenu;
        private string SignInOption { get; set; }
        private IMenuBL menuBL = new MenuBL();

        public MainMenu(SoilMatesContext context)
        {
            this._loginMenu = new LoginMenu(/*add context*/);
            this._signupMenu = new SignupMenu(new DBrepo(context), new DBrepo(context));
        }

        public void Start()
        {
            Console.WriteLine("Welcome to SoilMates!");

            bool isValidInput;
            string userInput;
            do
            {
                Console.WriteLine("Please select a sign in option:");
                Console.WriteLine("[0] Login");
                Console.WriteLine("[1] SignUp");
                Console.WriteLine("[x] Exit");
                userInput = Console.ReadLine();
                isValidInput = this.menuBL.SignInInputValidation(userInput);  //TODO 

            } while (!isValidInput);

            switch (userInput)
            {
                case "0":
                    this._signupMenu.Start();
                    //LoginMenu();
                    break;
                case "1":
                    // SignUpMenu();
                    // Console.WriteLine("Thank you for signing up, now redirecting you to login options...\n");
                    // LoginMenu();
                    break;
                default:
                    return;
            }

            //this.SignInOption = userInput;
        }

        // /// <summary>
        // /// Selects menu for signin or login
        // /// </summary>
        // public void SelectSignInMenu()
        // {
        //     switch (this.SignInOption)
        //     {
        //         case "0":
        //             LoginMenu();
        //             break;
        //         case "1":
        //             SignUpMenu();
        //             Console.WriteLine("Thank you for signing up, now redirecting you to login options...\n");
        //             LoginMenu();
        //             break;
        //         default:
        //             return;
        //     }
        // }

        // /// <summary>
        // /// Prints sign up menu
        // /// </summary>
        // public void SignUpMenu()
        // {
        //     Console.WriteLine("Please enter your information to sign up to SoilMates");
        //     //TODO use Business layer to input validate user
        //     Console.WriteLine("Enter your name:");
        //     string name = Console.ReadLine();
        //     Console.WriteLine("Enter your Email: ");
        //     string email = Console.ReadLine();
        //     Console.WriteLine("Enter your password: ");
        //     string password = Console.ReadLine();

        //     //make repo for a user to "persist" data 
        // }

        // /// <summary>
        // /// Prints login menu for either customer or employee
        // /// </summary>
        // public void LoginMenu()
        // {
        //     User user = LoginInUser();

        //     if (user.Name.Equals("customer")) //TODO for testinf purposes using customer  
        //     {
        //         bool isValidMenuItem;
        //         do
        //         {
        //             PrintCustomerMenuOptions();
        //             isValidMenuItem = this.menuBL.CustomerMenuInputValidation(this.userInput);

        //         } while (!isValidMenuItem || !userInput.Equals("x"));

        //     }
        //     else
        //     {
        //         bool isValidMenuItem;
        //         do
        //         {
        //             PrintEmployeeMenu();
        //             isValidMenuItem = this.menuBL.EmployeeMenuInputValidation(this.userInput);
        //         } while (!isValidMenuItem || !userInput.Equals("x"));
        //     }
        // }

        // /// <summary>
        // /// Menu items specific to managers
        // /// </summary>
        // public void PrintEmployeeMenu()
        // {
        //     Console.WriteLine();
        //     Console.WriteLine("Welcome {0} to SoilMates Employee Portal:", "FIX");
        //     Console.WriteLine("[0] Print Store Inventory"); //Check products in store location
        //     Console.WriteLine("[1] Print Plant Inventory");  //Check product inventory by product type
        //     Console.WriteLine("[2] Add Product to Inventory"); //add new product
        //     Console.WriteLine("[3] Remove Product from inventory"); //remove product
        //     Console.WriteLine("[x] Exit"); //remove product

        //     userInput = Console.ReadLine();
        // }

        // /// <summary>
        // /// Menu items specific to customers
        // /// </summary>
        // public void PrintCustomerMenuOptions()
        // {
        //     Console.WriteLine();
        //     Console.WriteLine("Welcome {0} to SoilMates Plant Store!", "FIX");
        //     Console.WriteLine("[0] Adopt A Plant"); //shop by plant
        //     Console.WriteLine("[1] Find A Plant");  //shop by inventory at a location
        //     Console.WriteLine("[2] Find the right plant for you"); //personality quiz
        //     Console.WriteLine("[3] View Order History");
        //     Console.WriteLine("[4] About Us");
        //     Console.WriteLine("[x] Exit"); //remove product

        //     userInput = Console.ReadLine();
        // }


        // /// <summary>
        // /// Logs user in given console input from user
        // /// </summary>
        // /// <returns></returns>
        // public User LoginInUser()
        // {
        //     //TODO add BL for loginValidation
        //     Console.WriteLine("Login:");
        //     Console.WriteLine("Enter your email: ");
        //     string name = Console.ReadLine();
        //     Console.WriteLine("Enter your password");
        //     string password = Console.ReadLine();
        //     //TODO get user from database for now assume customer and valid input

        //     User user = new Customer("customer", "email", 1);
        //     return user;
        // }

    }
}