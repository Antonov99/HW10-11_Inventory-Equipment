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

        public bool Consume(Vector2Int posiiton)
        {
            if (_inventory.TryGetItem(posiiton, out Item item))
            {
                return this.Consume(item);
            }

            return false;
        }

        public bool Consume(Item item)
        {
            if (!this.CanConsume(item))
            {
                return false;
            }
            
            _itemRemover.Remove(item);
            this.OnItemConsumed?.Invoke(item);
            return true;
        }
    }
}