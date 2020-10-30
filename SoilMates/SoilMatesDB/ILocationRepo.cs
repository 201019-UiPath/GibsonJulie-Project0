using System.Collections.Generic;
using System.Threading.Tasks;
using SoilMatesDB.Models;

namespace SoilMatesDB
{
    public interface ILocationRepo
    {
        List<Location> GetAllLocations();

        void AddLocation(Location location);

        Location GetLocationById(int id);
    }
}