using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    public interface IInventoryService
    {
        void AddInventory(Inventory inventory);
        List<Inventory> GetAllInventory();
        List<Inventory> GetInventoryItemByProductId(int id);
        List<Inventory> GetInvetoryItemByLocationId(int id);

        void RemoveInventoryItem(Inventory item);
    }

    public class InventoryService : IInventoryService
    {
        private IIventoryRepo repo;

        public InventoryService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddInventory(Inventory inventory)
        {
            repo.AddInventory(inventory);
        }

        public List<Inventory> GetAllInventory()
        {
            return repo.GetAllInventory();
        }

        public List<Inventory> GetInvetoryItemByLocationId(int id)
        {
            return repo.GetInventoryItemByLocationId(id);
        }

        public List<Inventory> GetInventoryItemByProductId(int id)
        {
            return repo.GetInventoryItemByProductId(id);
        }

        public void RemoveInventoryItem(Inventory item)
        {
            repo.RemoveInvetoryItem(item);
        }

    }
}