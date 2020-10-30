using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB
{
    public interface IIventoryRepo
    {
        List<Inventory> GetAllInventory();

    }
}