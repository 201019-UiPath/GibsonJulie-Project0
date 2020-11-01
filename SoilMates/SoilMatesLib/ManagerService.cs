using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public interface IManagerService
    {
        void AddManager(Manager newManager);
        List<Manager> GetAllManager();

        void RemoveManager(Manager manager);
    }

    public class ManagerService : IManagerService
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

        public void RemoveManager(Manager manager)
        {
            repo.RemoveManager(manager);
        }
    }
}