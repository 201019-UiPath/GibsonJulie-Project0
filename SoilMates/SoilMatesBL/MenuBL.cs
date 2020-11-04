using System.Text.RegularExpressions;
using System;

namespace SoilMatesBL
{
    /// <summary>
    /// Menu user input validation 
    /// </summary>
    public class MenuBL : IMenuBL
    {
        /// <summary>
        /// Checks if user signin input is valid based on sign options
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool SignInInputValidation(string input)
        {
            string loginInputPattern = "[0-1x]";
            string message = "Please select from options.\n";
            return MenuOptionsValidation(loginInputPattern, input, message);
        }

        public bool LoginInInputValidation(string input)
        {
            string loginInputPattern = "[0-1x]";
            string message = "Please select from options.\n";
            return MenuOptionsValidation(loginInputPattern, input, message);
        }

        /// <summary>
        /// Checks if customer entered valid menu option 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CustomerMenuInputValidation(string input)
        {
            string customerInputPattern = "[0-3x]";
            string message = "Please select from menu options.\n";
            return MenuOptionsValidation(customerInputPattern, input, message);
        }

        /// <summary>
        /// check manager intered a valid input based on customer options 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool EmployeeMenuInputValidation(string input)
        {
            string customerInputPattern = "[0-5x]";
            string message = "Please select from menu options.\n";
            return MenuOptionsValidation(customerInputPattern, input, message);
        }

        /// <summary>
        /// Check if user entered a valid name
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool NameValidation(string input)
        {
            string namePattern = "[a-zA-Z]";
            string message = "Invalid name, do not use numbers or special characters.\n";
            return MenuOptionsValidation(namePattern, input, message);
        }

        /// <summary>
        /// Check if email is in proper format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool EmailValidation(string input)
        {
            string namePattern = "^\\S+@\\S+.\\S+$";
            string message = "Invalid email!\n";
            return MenuOptionsValidation(namePattern, input, message);
        }

        /// <summary>
        /// Compares given input to allowable regex pattern and displayes message
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="input"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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