namespace SoilMatesBL
{
    public interface IMenuBL
    {
        bool SignInInputValidation(string input);

        bool CustomerMenuInputValidation(string input);

        bool EmployeeMenuInputValidation(string input);

        bool MenuOptionsValidation(string pattern, string input, string message);

        bool NameValidation(string input);

        bool EmailValidation(string input);
    }
}