using System.Collections.Generic;


namespace SoilMatesBL
{
    /// <summary>
    /// User login and signup methods
    /// </summary>
    public interface IUsersBL
    {
        /// <summary>
        /// Validate Users login information
        /// </summary>
        void LoginValidation();

        /// <summary>
        /// Validate Users SignUp information
        /// </summary>
        void SignUpValidation();

        /// <summary>
        /// Add user to Repo
        /// </summary>
        void SignUpUser();

        /// <summary>
        /// Retrieve user information from the database once user is logged in 
        /// </summary>
        void LoginUser();

        /// <summary>
        /// Get all users 
        /// </summary>
        /// <returns></returns>
        //List<Users> GetAllUsers();
    }
}