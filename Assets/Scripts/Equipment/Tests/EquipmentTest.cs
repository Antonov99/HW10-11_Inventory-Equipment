using Equipment.Scripts;
using GameEngine;
using NUnit.Framework;
using UnityEngine;

public class EquipmentTest
{
    private Player _player;
    
    [SetUp]
    public void SetUp()
    {
        _player = new Player();
    }
    
    [Test]
    public void EquipmentTestSimplePasses()
    {
        //Arrange:
        Inventory inventory = new Inventory(5, 5);
        InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);
        ItemEquipper itemEquipper = new ItemEquipper(inventory);
        InventoryItemStatsObserver observer = new InventoryItemStatsObserver(_player, itemEquipper);
        observer.Initialize();
        
        Item item = new Item { Title = "Sword", Size = new Vector2Int(1,1)};
        EquipableComponent equipableComponent = new EquipableComponent{isEquipped = false, type = "Weapon"};
        PowerComponent powerComponent = new PowerComponent();
        item.AddComponent(equipableComponent);
        item.AddComponent(powerComponent);
        
        inventoryItemAdder.AddItem(item, new Vector2Int(0, 0));
        
        //Act:
        bool success = itemEquipper.Equip(new Vector2Int(0, 0));
        
        //Assert:
        Assert.IsTrue(inventory.HasItem(0,0));
        Assert.AreEqual(4,_player.power);
        Assert.IsTrue(success);
        observer.Dispose();
    }
}
