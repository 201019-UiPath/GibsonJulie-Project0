using System;
using SoilMatesDB;
using SoilMatesDB.Models;
using SoilMatesLib;

namespace SoilMatesUI.Menu
{
    public class SignupMenu : IMenu
    {
        string userInput;
        ICustomerRepo customerRepo;
        IManagerRepo ManagerRepo;

        CustomerService customerService;

        public SignupMenu(ICustomerRepo customerRepo, IManagerRepo managerRepo)
        {
            this.customerRepo = customerRepo;
            this.ManagerRepo = managerRepo;
            this.customerService = new CustomerService(customerRepo);
        }

        public void Start()
        {
            Console.WriteLine("[0] Customer");
            Console.WriteLine("[1] Manager");
            this.userInput = Console.ReadLine();

            do
            {
                switch (userInput)
                {
                    case "0":
                        //call create a hero, get hero details
                        Customer newCustomer = GetCutomerDetails();
                        //call the business logic and the repo
                        customerService.AddCustomer(newCustomer);
                        break;
                }
            } while (!userInput.Equals("3"));

        }

        public Customer GetCutomerDetails()
        {
            Customer customer = new Customer();
            Console.WriteLine("Please enter your information to sign up to SoilMates");
            //TODO use Business layer to input validate user
            Console.WriteLine("Enter your name:");
            customer.Name = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            customer.Password = Console.ReadLine();

            return customer;

        }
    }
}