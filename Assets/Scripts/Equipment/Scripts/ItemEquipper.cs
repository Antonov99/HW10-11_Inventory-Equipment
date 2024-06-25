using System;
using GameEngine;
using JetBrains.Annotations;
using UnityEngine;

namespace Equipment.Scripts
{
    [UsedImplicitly]
    public sealed class ItemEquipper
    {
        public Action<Item> onItemEquiped;
        public Action<Item> onItemUnequiped;
        
        private readonly Inventory _inventory;

        public ItemEquipper(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool Equip(Vector2Int point)
        {
            if (!_inventory.TryGetItem(point,out Item item))
                return false;
            
            if (!item.TryGetComponent(out EquippableComponent component))
                return false;

            if (component.isEquipped)
                return false;
            
            component.isEquipped = true;
            onItemEquiped?.Invoke(item);
            
            return true;
        }
        
        public bool Unequip(Vector2Int point)
        {
            if (!_inventory.TryGetItem(point,out Item item))
                return false;
            
            if (!item.TryGetComponent(out EquippableComponent component))
                return false;

            if (!component.isEquipped)
                return false;
            
            component.isEquipped = false;
            onItemUnequiped?.Invoke(item);
            
            return true;
        }
    }
}