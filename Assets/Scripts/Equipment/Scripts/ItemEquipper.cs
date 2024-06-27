using System;
using System.Collections.Generic;
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

        private readonly Dictionary<string, bool> _equipment = new();
        
        public ItemEquipper(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool Equip(Vector2Int point)
        {
            if (!_inventory.TryGetItem(point,out Item item))
                return false;
            
            if (!item.TryGetComponent(out EquipableComponent component))
                return false;

            if (component.isEquipped)
            {
                Debug.Log("This item is already equiped");
                return false;
            }

            if (IsEquipmentTypeAlreadyOn(component.type))
            {
                Debug.Log("Another item of this type is already on");
                return false;
            }

            component.isEquipped = true;
            onItemEquiped?.Invoke(item);
            
            return true;
        }
        
        public bool Unequip(Vector2Int point)
        {
            if (!_inventory.TryGetItem(point,out Item item))
                return false;
            
            if (!item.TryGetComponent(out EquipableComponent component))
                return false;

            if (!component.isEquipped)
                return false;

            if (_equipment.TryGetValue(component.type, out bool value))
                _equipment[component.type] = false;
            else
                _equipment.Add(component.type, false);
            
            component.isEquipped = false;
            onItemUnequiped?.Invoke(item);
            
            return true;
        }
        
        private bool IsEquipmentTypeAlreadyOn(string type)
        {
            if (_equipment.TryGetValue(type, out bool value))
            {
                if (value)
                    return true;
            }
            else
            {
                _equipment.Add(type, true);
            }

            return false;
        }
    }
}