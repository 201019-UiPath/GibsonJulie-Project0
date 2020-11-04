using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;
using System;
using Serilog;

namespace SoilMatesLib
{
    /// <summary>
    /// Service for manager model to instact with repository
    /// </summary>
    public class ManagerService
    {
        private IManagerRepo repo;

        /// <summary>
        ///  Constructor for manager service with repository injection
        /// </summary>
        /// <param name="repo"></param>
        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds manager
        /// </summary>
        /// <param name="newManager"></param>
        public void AddManager(Manager newManager)
        {
            repo.AddManager(newManager);
        }

        /// <summary>
        /// Sign up manager given user details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void SignUpManager(string name, string email, string password)
        {

            if (repo.GetManagerByEmail(email) != null)
            {
                Log.Warning("Existing user attempted new sign up.");
                throw new Exception("Manager already exists!");
            }
            Manager newManager = new Manager(name, email, password);
            AddManager(newManager);
            SaveChanges();
        }


        /// <summary>
        /// Returns manager with matching password and email
        /// </summary>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Manager GetManagerByLogin(string password, string email)
        {
            return repo.GetManagerByLogin(password, email);
        }


        /// <summary>
        /// Save changes to repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }
    }
}