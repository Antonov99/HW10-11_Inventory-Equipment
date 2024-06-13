using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    public sealed class InventoryItemAdder
    {
        private readonly Inventory inventory;

        public InventoryItemAdder(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public bool CanAddItem(Item item, Vector2Int position)
        {
            Vector2Int itemSize = item.Size;
            Item[,] cells = this.inventory.cells;
            
            if (position.x + itemSize.x >= this.inventory.Width ||
                position.y + itemSize.y >= this.inventory.Height ||
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
            if (!this.CanAddItem(item, position))
            {
                return false;
            }
            
            Vector2Int itemSize = item.Size;
            List<Vector2Int> points = new List<Vector2Int>(itemSize.x * itemSize.y);

            Item[,] cells = this.inventory.cells;
            Dictionary<Item, List<Vector2Int>> itemMap = this.inventory.itemMap;
            
            for (int x = position.x; x < position.x + itemSize.x; x++)
            {
                for (int y = position.y; y < itemSize.y + position.y; y++)
                {
                    cells[x, y] = item;
                    points.Add(new Vector2Int(x, y));
                }
            }

            itemMap.Add(item, points);
            this.inventory.OnItemAdded?.Invoke(item);
            return true;
        }
    }
}