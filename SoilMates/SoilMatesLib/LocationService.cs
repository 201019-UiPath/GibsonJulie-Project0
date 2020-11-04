using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;
using System;

namespace SoilMatesLib
{
    /// <summary>
    /// Provides services for location model to interact with repository
    /// </summary>
    public class LocationService
    {
        private ILocationRepo repo;

        public LocationService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds location to our enterprise
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }

        public void AddNewLocation(string name, string address)
        {
            Location location = new Location(name, address);
            if (!GetAllLocations().Any())
            {
                repo.AddLocation(location);
            }
            else
            {
                Location isDuplicate = GetLocationByName(location.Name);
                if (isDuplicate == null)
                {
                    AddLocation(location);
                }
                else
                {
                    //if store name exists, check to see if if has the same address if so location is duplicate and not added 
                    if (isDuplicate.Address == location.Address)
                    {
                        throw new Exception("Location already exists at this address.\n");
                    }
                    else
                    {
                        AddLocation(location);
                    }
                }
            }
        }

        /// <summary>
        /// Returns list of locations in repository
        /// </summary>
        /// <returns></returns>
        public List<Location> GetAllLocations()
        {
            return repo.GetAllLocations();
        }

        /// <summary>
        /// Returns location by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetLocationById(int id)
        {
            return repo.GetLocationById(id);
        }

        /// <summary>
        /// Get location by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Location GetLocationByName(string name)
        {
            return repo.GetLocationByName(name);
        }

        /// <summary>
        /// Remove a location 
        /// </summary>
        /// <param name="location"></param>
        public void RemoveLocation(Location location)
        {
            repo.RemoveLocation(location);
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
