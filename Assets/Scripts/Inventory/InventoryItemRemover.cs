using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public sealed class InventoryItemRemover
    {
        private readonly Inventory _inventory;

        public InventoryItemRemover(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool CanRemove(Item item)
        {
            return _inventory.itemMap.ContainsKey(item);
        }

        public bool Remove(Item item)
        {
            Dictionary<Item, List<Vector2Int>> itemMap = _inventory.itemMap;
            Item[,] inventoryCells = _inventory.cells;

            if (!itemMap.Remove(item, out List<Vector2Int> cells))
            {
                return false;
            }

            foreach (var points in cells)
            {
                inventoryCells[points.x, points.y] = null;
            }
            
            _inventory.OnItemRemoved?.Invoke(item);
            return true;
        }
    }
}