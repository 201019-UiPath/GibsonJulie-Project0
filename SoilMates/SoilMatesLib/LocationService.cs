using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public interface ILocationService
    {
        void AddLocation(Location newLocation);
        List<Location> GetAllLocations();
        Location GetLocationById(int id);

        void RemoveLocation(Location location);
    }

    public class LocationService : ILocationService
    {
        private ILocationRepo repo;

        public LocationService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location newLocation)
        {
            repo.AddLocation(newLocation);
        }

        public List<Location> GetAllLocations()
        {
            return repo.GetAllLocations();
        }

        public Location GetLocationById(int id)
        {
            return repo.GetLocationById(id);
        }

        public void RemoveLocation(Location location)
        {
            repo.RemoveLocation(location);
        }

    }
}
