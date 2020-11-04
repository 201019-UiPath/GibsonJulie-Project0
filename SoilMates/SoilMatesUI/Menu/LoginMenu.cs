using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;
using SoilMatesBL;

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

        MenuBL menuBL;

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
            this.menuBL = new MenuBL();
        }

        /// <summary>
        /// Entry point for login UI
        /// </summary>
        public void Start()
        {
            bool isValidInput;
            do
            {
                PrintLoginOptions();
                userInput = Console.ReadLine();
                isValidInput = menuBL.LoginInInputValidation(userInput);
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
            } while (!isValidInput || !userInput.Equals("x"));
        }

        /// <summary>
        /// Print Menu options
        /// </summary>
        public void PrintLoginOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Select type of user: ");
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            Console.WriteLine("[x] exit");
        }

        /// <summary>
        /// Gets customer details for login
        /// </summary>
        /// <returns></returns>
        public Customer GetCustomerDetails()
        {
            string email, pw;
            do
            {
                Console.WriteLine("Email: ");
                email = Console.ReadLine().ToLower();
                Console.WriteLine("Password: ");
                pw = Console.ReadLine();
            } while (!menuBL.EmailValidation(email));

            return customerService.GetCustomerByLogin(pw, email);
        }

        /// <summary>
        /// Gets manager details for login
        /// </summary>
        /// <returns></returns>
        public Manager GetManagerDetails()
        {
            string email, pw;
            do
            {
                Console.WriteLine("Enter your Email: ");
                email = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your password: ");
                pw = Console.ReadLine();
            } while (!menuBL.EmailValidation(email));

            return managerService.GetManagerByLogin(pw, email);
        }
    }
}