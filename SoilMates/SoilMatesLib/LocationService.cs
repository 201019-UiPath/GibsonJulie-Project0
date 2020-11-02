using System.Runtime.CompilerServices;
using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public class LocationService
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
        public void SaveChanges()
        {
            repo.SaveChanges();
        }
    }
}
