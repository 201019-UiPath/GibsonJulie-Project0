using System;
using SoilMatesBL;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Start of main menu
    /// </summary>
    public class MainMenu : IMenu
    {
        public int MenuOption { get; set; }

        public void Greeting()
        {
            Console.WriteLine("Welcome to SoilMates!");

            bool isValidInput;
            string input;
            do
            {
                Console.WriteLine("Please select a sign in option:");
                Console.WriteLine("[0] Login");
                Console.WriteLine("[1] SignUp");

                input = Console.ReadLine();
                isValidInput = SoilMatesBL.MenuBL.SignInInputValidation(input);  //TODO 

            } while (!isValidInput);

            this.MenuOption = Int32.Parse(input);
        }

        public void SelectSignInMenu()
        {
            switch (this.MenuOption)
            {
                case 0:
                    LoginMenu();
                    break;
                case 1:
                    SignUpMenu();
                    Console.WriteLine("Add signup succeeded");
                    LoginMenu();
                    break;
            }
        }

        public void SignUpMenu()
        {
            Console.WriteLine("Please enter your information to sign up to SoilMates");

            //TODO use Business layer to input validate user
            Console.WriteLine("Enter your name:");
            Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            Console.ReadLine();

            //get user information from user to store in database
            //might include a personality test to match plants
        }

        public void LoginMenu()
        {
            //TODO add BL for loginValidation
            Console.WriteLine("Please Login:");
            Console.WriteLine("Enter your email: ");
            Console.ReadLine();
            Console.WriteLine("Enter your password");
            Console.ReadLine();

            //get user login information
            //bool isCustomer = true;
            if (false)
            {
                PrintCustomerMenuOptions();
            }
            else
            {
                PrintEmployeeMenu();
            }

        }

        public void PrintEmployeeMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[0] Print Store Inventory"); //Check products in store location
            Console.WriteLine("[1] Print Plant Inventory");  //Check product inventory by product type
            Console.WriteLine("[2] Add Product to Inventory"); //add new product
            Console.WriteLine("[3] Remove Product from inventory"); //remove product

        }

        public void PrintCustomerMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("[0] Adopt A Plant"); //shop by plant
            Console.WriteLine("[1] Find A Plant");  //shop by inventory at a location
            Console.WriteLine("[2] Find the right plant for you"); //personality quiz
            Console.WriteLine("[3] View Order History");
            Console.WriteLine("[4] About Us");
        }

    }
}