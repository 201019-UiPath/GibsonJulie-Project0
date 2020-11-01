using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    public interface IManagerRepo
    {
        void AddManager(Manager manager);
        List<Manager> GetAllManagers();
        Manager GetManagerById(int id);
        Manager GetManagerByLogin(string password, string email);
        void RemoveManager(Manager manager);
    }
}