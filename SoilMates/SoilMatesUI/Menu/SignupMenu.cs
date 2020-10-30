using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class SignupMenu : IMenu
    {
        int customerUser = 0;
        int managerUser = 1;
        string userInput;
        IRepository userRepo;
        CustomerService customerService;
        ManagerService managerService;

        public SignupMenu(IRepository repo)
        {
            this.userRepo = repo;
            this.customerService = new CustomerService(userRepo);
            this.managerService = new ManagerService(userRepo);
        }

        public void Start()
        {
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            Console.WriteLine("[x] exit");
            userInput = Console.ReadLine(); //TODO add inputvalidation

            switch (userInput)
            {
                case "0":
                    //call create a hero, get hero details
                    Customer newCustomer = GetCustomerDetails();
                    customerService.AddCustomer(newCustomer);
                    break;
                case "1":
                    Manager newManager = GetManagerDetails();
                    managerService.AddManager(newManager);
                    break;
            }
        }

        public Manager GetManagerDetails()
        {
            Manager user = new Manager();
            Console.WriteLine("Please enter your information to sign up to SoilMates");
            Console.WriteLine("Enter your name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            user.Password = Console.ReadLine();
            user.UserType = managerUser;
            return user;
            //TODO use Business layer to input validate user
        }

        public Customer GetCustomerDetails()
        {
            Customer user = new Customer();
            Console.WriteLine("Please enter your information to sign up to SoilMates");
            //TODO use Business layer to input validate user
            Console.WriteLine("Enter your name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            user.Password = Console.ReadLine();
            user.UserType = customerUser;
            return user;
            //TODO use Business layer to input validate user
        }


    }
}