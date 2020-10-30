using System;
using SoilMatesBL;
using SoilMatesDB.Models;

namespace SoilMatesUI.Menu
{
    public class CustomerMenu
    {
        private string userInput;

        private IMenuBL menuBL = new MenuBL();

        public void Start(Customer user)
        {
            Console.WriteLine();
            Console.WriteLine("{0}, Welcome to SoilMates Plant Store!", user.Name);

            bool isValidMenuItem;
            do
            {
                PrintCustomerMenuOptions();
                isValidMenuItem = menuBL.CustomerMenuInputValidation(userInput);
                if (isValidMenuItem && userInput.Equals("0"))
                {
                    //Get products to choose a plant 
                }

            } while (!isValidMenuItem || !userInput.Equals("x"));

        }

        public void PrintCustomerMenuOptions()
        {
            Console.WriteLine("[0] Adopt A Plant");                 //shop by plant
            Console.WriteLine("[1] Find A Plant");                  //shop by inventory at a location
            Console.WriteLine("[2] Find the right plant for you");  //personality quiz
            Console.WriteLine("[3] View Order History");
            Console.WriteLine("[4] About Us");
            Console.WriteLine("[x] Exit");                          //remove product

            userInput = Console.ReadLine();
        }

    }

}