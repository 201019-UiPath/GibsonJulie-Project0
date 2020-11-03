using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    /// <summary>
    /// Login menu class
    /// </summary>
    public class LoginMenu : IMenu
    {
        string userInput;
        IRepository userRepo;
        CustomerService customerService;
        ManagerService managerService;
        CustomerMenu customerMenu;
        ManagerMenu managerMenu;

        /// <summary>
        /// Login menu constructor
        /// </summary>
        /// <param name="userRepo"></param>
        public LoginMenu(IRepository userRepo)
        {
            this.userRepo = userRepo;
            this.customerService = new CustomerService(userRepo);
            this.managerService = new ManagerService(userRepo);
            this.customerMenu = new CustomerMenu(userRepo);
            this.managerMenu = new ManagerMenu(userRepo);
        }

        /// <summary>
        /// Entry point for login UI
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome, please sign in: ");
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            Console.WriteLine("[x] exit");
            userInput = Console.ReadLine(); //TODO add inputvalidation

            switch (userInput)
            {
                case "0":
                    Customer customer = GetCustomerDetails();
                    if (customer == null) Console.WriteLine("User Not Found");
                    else
                    {
                        Console.WriteLine("Customer Login successfull\n");
                        customerMenu.Start(customer);
                    }
                    break;
                case "1":
                    Manager manager = GetManagerDetails();
                    if (manager == null) Console.WriteLine("Login unsuccessfull");
                    else
                    {
                        Console.WriteLine("Manager Login successfull\n");
                        managerMenu.Start(manager);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets customer details for login
        /// </summary>
        /// <returns></returns>
        public Customer GetCustomerDetails()
        {
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pw = Console.ReadLine();
            return userRepo.GetCustomerByLogin(pw, email); //TODO use Business layer to input validate user
        }

        /// <summary>
        /// Gets manager details for login
        /// </summary>
        /// <returns></returns>
        public Manager GetManagerDetails()
        {
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pw = Console.ReadLine();
            return userRepo.GetManagerByLogin(pw, email); //TODO use Business layer to input validate user
        }
    }
}