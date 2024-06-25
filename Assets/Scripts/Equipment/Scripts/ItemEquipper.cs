using System;
using GameEngine;
using UnityEngine;

namespace Equipment.Scripts
{
    public sealed class ItemEquipper
    {
        public Action<Item> OnItemEquiped;
        public Action<Item> OnItemUnequiped;
        
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
            OnItemEquiped?.Invoke(item);
            
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
            OnItemUnequiped?.Invoke(item);
            
            return true;
        }
    }
}