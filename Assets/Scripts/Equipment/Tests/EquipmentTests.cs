using Equipment.Scripts;
using GameEngine;
using NUnit.Framework;
using UnityEngine;

namespace EquipmentModule
{
    public class EquipmentTests
    {
        [Test]
        public void Test()
        {
            Inventory inventory = new Inventory(5, 5);
            ItemEquipper itemEquipper = new ItemEquipper(inventory);
            InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);

            inventoryItemAdder.AddItem(new Item{Title = "Sword", Size = new Vector2Int(1,1)}, new Vector2Int(2, 2));
            
            itemEquipper.Equip(new Vector2Int(2,2));
            
            Assert.IsTrue(inventory.HasItem(2,2));
        }
    }
}