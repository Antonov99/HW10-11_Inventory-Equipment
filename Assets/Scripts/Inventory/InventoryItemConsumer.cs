using System;
using UnityEngine;

namespace GameEngine
{
    public sealed class InventoryItemConsumer
    {
        public event Action<Item> OnItemConsumed;

        private readonly Inventory _inventory;
        private readonly InventoryItemRemover _itemRemover;

        public InventoryItemConsumer(Inventory inventory, InventoryItemRemover itemRemover)
        {
            _inventory = inventory;
            _itemRemover = itemRemover;
        }

        public bool CanConsume(Item item)
        {
            if ((item.Flags & ItemFlags.CONSUMABLE) != ItemFlags.CONSUMABLE) //1111 * 0001 = 0001
            {
                return false;
            }

            if (!_itemRemover.CanRemove(item))
            {
                return false;
            }

            return true;
        }

        public bool Consume(Vector2Int position)
        {
            if (_inventory.TryGetItem(position, out Item item))
            {
                return Consume(item);
            }

            return false;
        }

        public bool Consume(Item item)
        {
            if (!CanConsume(item))
            {
                return false;
            }
            
            if(!_itemRemover.Remove(item))
                return false;
            
            OnItemConsumed?.Invoke(item);
            return true;
        }
    }
}