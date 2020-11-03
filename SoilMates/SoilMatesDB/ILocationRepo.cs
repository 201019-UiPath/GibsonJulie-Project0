using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    /// <summary>
    /// Interface for location Repository
    /// </summary>
    public interface ILocationRepo
    {
        List<Location> GetAllLocations();

        void AddLocation(Location location);

        Location GetLocationById(int id);

        Location GetLocationByName(string name);

        void RemoveLocation(Location location);

        void SaveChanges();
    }
}