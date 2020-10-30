using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class LoginMenu : IMenu
    {
        string userInput;
        IRepository userRepo;
        CustomerService customerService;
        ManagerService managerService;
        CustomerMenu customerMenu;
        ManagerMenu managerMenu;
        //TODO: ManagerMenu managerMenu;
        public LoginMenu(IRepository userRepo)
        {
            this.userRepo = userRepo;
            this.customerService = new CustomerService(userRepo);
            this.managerService = new ManagerService(userRepo);
            this.customerMenu = new CustomerMenu();
            this.managerMenu = new ManagerMenu(userRepo);
        }

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
                        Console.WriteLine("Customer Login successfull");
                        customerMenu.Start(customer);
                    }
                    break;
                case "1":
                    Manager manager = GetManagerDetails();
                    if (manager == null) Console.WriteLine("Login unsuccessfull");
                    else
                    {
                        Console.WriteLine("Manager Login successfull");
                        managerMenu.Start(manager);
                        //add manager menu
                    }
                    break;
            }
        }

        public Customer GetCustomerDetails()
        {
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pw = Console.ReadLine();
            return userRepo.GetCustomerByLogin(pw, email); //TODO use Business layer to input validate user
        }
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