using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class LoginMenu : IMenu
    {
        string userInput;
        ICustomerRepo customerRepo;
        IManagerRepo ManagerRepo;
        CustomerService customerService;
        ManagerService managerService;
        CustomerMenu customerMenu;

        //TODO: ManagerMenu managerMenu;

        public LoginMenu(ICustomerRepo customerRepo, IManagerRepo managerRepo)
        {
            this.customerRepo = customerRepo;
            this.ManagerRepo = managerRepo;
            this.customerService = new CustomerService(customerRepo);
            this.managerService = new ManagerService(managerRepo);
            this.customerMenu = new CustomerMenu();
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
                    else Console.WriteLine("Login successfull");
                    this.customerMenu(customerRepo);
                    break;
                case "1":
                    Manager manager = GetManagerDetails();
                    if (manager == null)
                    {
                        Console.WriteLine("Login unsuccessfull");
                    }
                    else Console.WriteLine("Login successfull");
                    break;
            }
        }

        public Customer GetCustomerDetails()
        {
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pw = Console.ReadLine();
            Customer customer = customerRepo.GetCustomerByLogin(pw, email);
            return customer; //TODO use Business layer to input validate user
        }

        public Manager GetManagerDetails()
        {
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string pw = Console.ReadLine();
            Manager manager = ManagerRepo.GetManagerByLogin(pw, email);
            return manager; //TODO use Business layer to input validate user
        }


    }
}