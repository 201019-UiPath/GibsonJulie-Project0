using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    /// <summary>
    /// Interface for Inventory Repository
    /// </summary>
    public interface IIventoryRepo
    {
        List<Inventory> GetAllInventory();
        void AddInventory(Inventory item);
        List<Inventory> GetInventoryItemByProductId(int id);
        List<Inventory> GetInventoryItemByLocationId(int id);
        void RemoveInvetoryItem(Inventory item);
        Inventory GetInventoryItem(int productId, int locationId);
        void SaveChanges();
    }
}