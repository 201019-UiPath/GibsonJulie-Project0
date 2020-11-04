using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;
using SoilMatesBL;
using Serilog;

namespace SoilMatesUI.Menu
{
    public class SignupMenu : IMenu
    {
        string userInput;
        IRepository userRepo;
        CustomerService customerService;
        ManagerService managerService;
        MenuBL menuBL;

        /// <summary>
        /// Signup menu UI constructor
        /// </summary>
        /// <param name="repo"></param>
        public SignupMenu(IRepository repo)
        {
            this.userRepo = repo;
            this.customerService = new CustomerService(userRepo);
            this.managerService = new ManagerService(userRepo);
            this.menuBL = new MenuBL();
        }

        /// <summary>
        /// Entry point for signup menu UI
        /// </summary>
        public void Start()
        {
            bool isValidInput;
            do
            {
                PrintSignUpOptions();
                userInput = Console.ReadLine();
                isValidInput = menuBL.LoginInInputValidation(userInput);
                switch (userInput)
                {
                    case "0":
                        GetCustomerDetails();
                        return;

                    case "1":
                        GetManagerDetails();
                        return;
                }
            } while (!isValidInput || !userInput.Equals("x"));
        }


        /// <summary>
        /// Print menu options
        /// </summary>
        public void PrintSignUpOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Select type of user:");
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            Console.WriteLine("[x] exit");
        }

        /// <summary>
        /// Get manger details from user
        /// </summary>
        /// <returns></returns>
        public void GetManagerDetails()
        {
            string name, email, password;
            do
            {
                Console.WriteLine("Please enter your information to sign up to SoilMates");
                Console.WriteLine("Enter your name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter your Email: ");
                email = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();

            } while (!menuBL.NameValidation(name) || !menuBL.EmailValidation(email));

            try
            {
                managerService.SignUpManager(name, email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get customer details
        /// </summary>
        /// <returns></returns>
        public void GetCustomerDetails()
        {
            string name, email, password;
            do
            {
                Console.WriteLine("Please enter your information to sign up to SoilMates");
                Console.WriteLine("Enter your name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter your Email: ");
                email = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();
            } while (!menuBL.NameValidation(name) || !menuBL.EmailValidation(email));
            try
            {
                customerService.SignUpCustomer(name, email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}