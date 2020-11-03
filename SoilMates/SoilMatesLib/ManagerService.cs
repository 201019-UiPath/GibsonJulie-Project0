using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

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
        /// Save changes to repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }
    }
}