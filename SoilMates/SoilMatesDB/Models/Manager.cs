namespace SoilMatesDB.Models
{
    /// <summary>
    /// Manager model
    /// </summary>
    public class Manager : User
    {
        public Manager()
        {
            UserType = 1;
        }
        public Manager(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.UserType = 1;
        }

    }
}