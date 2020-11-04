using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;
using System;
using Serilog;

namespace SoilMatesLib
{
    /// <summary>
    /// Allows access to inventory repository services
    /// </summary>
    public class InventoryService
    {
        private IIventoryRepo repo;

        public InventoryService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Adds inventory item
        /// </summary>
        /// <param name="inventory"></param>
        public void AddInventory(Inventory inventory)
        {
            //if product location combination exists just update quantity
            Inventory item = GetInventoryItem(inventory.ProductForeingId, inventory.LocationForeignId);
            if (item != null)
            {
                throw new Exception("Inventory item already exists.");
            }
            repo.AddInventory(inventory);
        }

        public void AddItemToInventory(Location location, Product product, int quantity)
        {
            Inventory item = new Inventory(location, product, location.LocationId, product.ProductId);
            try
            {
                AddInventory(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            UpdateQuantity(item, quantity);
            SaveChanges();
        }

        /// <summary>
        /// Gets all inventory items for every store
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            return repo.GetAllInventory();
        }

        /// <summary>
        /// Returns inventory for a specific location, specified by unique location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInvetoryItemByLocationId(int id)
        {
            return repo.GetInventoryItemByLocationId(id);
        }

        /// <summary>
        /// Returns inventory for based on product, to see where products are in different stores
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Inventory> GetInventoryItemByProductId(int id)
        {
            return repo.GetInventoryItemByProductId(id);
        }

        /// <summary>
        /// Removes an inventory item
        /// </summary>
        /// <param name="item"></param>
        public void RemoveInventoryItem(Inventory item)
        {
            repo.RemoveInvetoryItem(item);
        }

        /// <summary>
        /// Returns an inventory item given a unique product id and unique location id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Inventory GetInventoryItem(int productId, int locationId)
        {
            return repo.GetInventoryItem(productId, locationId);
        }

        /// <summary>
        /// Save changes in repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }

        /// <summary>
        /// Update quantity if inventory item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        public void UpdateQuantity(Inventory item, int quantity)
        {
            item.Quantity = quantity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="quantity"></param>
        public void SoldInventoryUpdate(Inventory item, int quantity)
        {
            if (item.Quantity < quantity)
            {
                throw new System.Exception("Quantity sold cannot excede amount inventory, continue with order. ");
            }
            item.Quantity -= quantity;
        }
    }
}