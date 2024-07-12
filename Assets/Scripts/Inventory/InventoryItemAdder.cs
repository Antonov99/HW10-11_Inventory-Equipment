using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public sealed class InventoryItemAdder
    {
        private readonly Inventory _inventory;

        public InventoryItemAdder(Inventory inventory)
        {
            _inventory = inventory;
        }

        private bool CanAddItem(Item item, Vector2Int position)
        {
            Vector2Int itemSize = item.Size;
            Item[,] cells = _inventory.cells;
            
            if (position.x + itemSize.x >= _inventory.width ||
                position.y + itemSize.y >= _inventory.height ||
                position.x < 0 || position.y < 0)
            {
                return false;
            }
            
            for (int x = position.x; x < position.x + itemSize.x; x++)
            {
                for (int y = position.y; y < itemSize.y + position.y; y++)
                {
                    if (cells[x, y] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool AddItem(Item item, Vector2Int position)
        {
            if (!CanAddItem(item, position))
            {
                return false;
            }
            
            Vector2Int itemSize = item.Size;
            List<Vector2Int> points = new List<Vector2Int>(itemSize.x * itemSize.y);

            Item[,] cells = _inventory.cells;
            Dictionary<Item, List<Vector2Int>> itemMap = _inventory.itemMap;
            
            for (int x = position.x; x < position.x + itemSize.x; x++)
            {
                for (int y = position.y; y < itemSize.y + position.y; y++)
                {
                    cells[x, y] = item;
                    points.Add(new Vector2Int(x, y));
                }
            }

            itemMap.Add(item, points);
            _inventory.OnItemAdded?.Invoke(item);
            return true;
        }
    }
}