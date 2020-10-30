using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesDB.Models
{
    public interface IIventoryRepo
    {
        List<Inventory> GetAllInventory();

    }
}