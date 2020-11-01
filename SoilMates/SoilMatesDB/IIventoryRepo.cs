using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    public interface IIventoryRepo
    {
        List<Inventory> GetAllInventory();

        void AddInventory(Inventory item);

        Inventory GetInventoryItemByProductId(int id);
        Inventory GetInventoryItemByLocationId(int id);

        List<Inventory> GetAllInInventory();

        List<Inventory> GetProductsByLocationId(Location location);

        List<Inventory> GetLocationsByProductId(Product product);
        void RemoveInvetoryItem(Inventory item);
    }
}