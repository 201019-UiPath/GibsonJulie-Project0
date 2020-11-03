namespace SoilMatesDB.Models
{
    /// <summary>
    /// User model to create managers and customers
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}