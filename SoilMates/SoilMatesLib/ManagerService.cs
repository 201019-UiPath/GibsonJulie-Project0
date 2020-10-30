using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public class ManagerService
    {
        private IManagerRepo repo;

        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public void AddManager(Manager newManager)
        {
            repo.AddManager(newManager);
        }

        public List<Manager> GetAllManager()
        {
            return repo.GetAllManagers();
        }

    }
}