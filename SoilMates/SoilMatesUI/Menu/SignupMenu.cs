using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;
using SoilMatesBL;

namespace SoilMatesUI.Menu
{
    public class SignupMenu : IMenu
    {
        int customerUser = 0; //to determine type of user 
        int managerUser = 1;
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
                        Customer newCustomer = GetCustomerDetails();
                        customerService.AddCustomer(newCustomer);
                        customerService.SaveChanges();
                        break;
                    case "1":
                        Manager newManager = GetManagerDetails();
                        managerService.AddManager(newManager);
                        managerService.SaveChanges();
                        break;
                }
            } while (!isValidInput || !userInput.Equals("x"));
        }


        /// <summary>
        /// Print menu options
        /// </summary>
        public void PrintSignUpOptions()
        {
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            Console.WriteLine("[x] exit");
        }

        /// <summary>
        /// Get manger details from user
        /// </summary>
        /// <returns></returns>
        public Manager GetManagerDetails()
        {
            Manager user = new Manager();
            do
            {
                Console.WriteLine("Please enter your information to sign up to SoilMates");
                Console.WriteLine("Enter your name:");
                user.Name = Console.ReadLine();
                Console.WriteLine("Enter your Email: ");
                user.Email = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                user.Password = Console.ReadLine();
                user.UserType = managerUser;
            } while (!menuBL.NameValidation(user.Name) || !menuBL.EmailValidation(user.Email));
            return user;

        }

        /// <summary>
        /// Get customer details
        /// </summary>
        /// <returns></returns>
        public Customer GetCustomerDetails()
        {
            Customer user = new Customer();
            do
            {
                Console.WriteLine("Please enter your information to sign up to SoilMates");
                //TODO use Business layer to input validate user details
                Console.WriteLine("Enter your name:");
                user.Name = Console.ReadLine();
                Console.WriteLine("Enter your Email: ");
                user.Email = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                user.Password = Console.ReadLine();
                user.UserType = customerUser;

                //TODO make customer controller and add to constuctor!!!

            } while (!menuBL.NameValidation(user.Name) || !menuBL.EmailValidation(user.Email));

            return user;
        }
    }
}