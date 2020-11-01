using System.Text.RegularExpressions;
using System;

namespace SoilMatesBL
{
    public class MenuBL : IMenuBL
    {
        public bool SignInInputValidation(string input)
        {
            //check user intered a valid input based on sign options 
            string loginInputPattern = "[0-1x]";
            string message = "Please select from menu options.\n";
            return MenuOptionsValidation(loginInputPattern, input, message);
        }

        public bool CustomerMenuInputValidation(string input)
        {
            //check user intered a valid input based on customer options 
            string customerInputPattern = "[0-3x]";
            string message = "Please select from menu options.\n";
            return MenuOptionsValidation(customerInputPattern, input, message);
        }

        public bool EmployeeMenuInputValidation(string input)
        {
            //check user intered a valid input based on customer options 
            string customerInputPattern = "[0-4x]";
            string message = "Please select from menu options.\n";
            return MenuOptionsValidation(customerInputPattern, input, message);
        }

        public bool NameValidation(string input)
        {
            string namePattern = "[a-zA-Z]";
            string message = "Invalid name, do not use numbers or special characters.\n";
            return MenuOptionsValidation(namePattern, input, message);
        }

        public bool EmailValidation(string input)
        {
            string namePattern = "^\\S+@\\S+.\\S+$";
            string message = "Invalid email!\n";
            return MenuOptionsValidation(namePattern, input, message);
        }

        public bool MenuOptionsValidation(string pattern, string input, string message)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(message);
                return false;
            }

            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input)) return true;
            Console.WriteLine(message);
            return false;
        }
    }
}