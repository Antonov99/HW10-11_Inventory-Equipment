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
    public void ItemAddedTest1()
    {
        //Arrange:
        Inventory inventory = new Inventory(5, 5);
        InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);
        
        Item item = new Item { Title = "Sword", Size = new Vector2Int(1,1)};
        
        //Act:
        bool success1 = inventoryItemAdder.AddItem(item, new Vector2Int(0, 0));
        bool success2 = inventoryItemAdder.AddItem(item, new Vector2Int(7, 4));
        
        //Assert:
        Assert.IsTrue(inventory.HasItem(0,0));
        Assert.IsTrue(success1);
        Assert.IsFalse(success2);
    }
    
    [Test]
    public void ItemAddedTest2()
    {
        //Arrange:
        Inventory inventory = new Inventory(0, 0);
        InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);
        
        Item item = new Item { Title = "Sword", Size = new Vector2Int(1,1)};
        
        //Act:
        bool success1 = inventoryItemAdder.AddItem(item, new Vector2Int(0, 0));
        bool success2 = inventoryItemAdder.AddItem(item, new Vector2Int(7, 4));
        
        //Assert:
        Assert.IsFalse(success1);
        Assert.IsFalse(success2);
    }

    [Test]
    public void ItemEquipedTest1()
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
        bool success1 = itemEquipper.Equip(new Vector2Int(0, 0));
        
        //Assert:
        
        Assert.AreEqual(4,_player.power);
        Assert.IsTrue(success1);
        
        observer.Dispose();
    }

    [Test]
    public void ItemEquipedTest2()
    {
        //Arrange:
        Inventory inventory = new Inventory(5, 5);
        InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);
        ItemEquipper itemEquipper = new ItemEquipper(inventory);
        InventoryItemStatsObserver observer = new InventoryItemStatsObserver(_player, itemEquipper);
        observer.Initialize();
        
        Item item = new Item { Title = "Shield", Size = new Vector2Int(2,3)};
        EquipableComponent equipableComponent = new EquipableComponent{isEquipped = false, type = "Armor"};
        ArmorComponent armorComponent = new ArmorComponent();
        item.AddComponent(equipableComponent);
        item.AddComponent(armorComponent);
        
        inventoryItemAdder.AddItem(item, new Vector2Int(0, 0));
        //Act:
        bool success1 = itemEquipper.Equip(new Vector2Int(0, 0));
        
        //Assert:
        Assert.AreEqual(3,_player.armor);
        Assert.IsTrue(success1);

        observer.Dispose();
    }
    
    [Test]
    public void ItemEquipedTest3()
    {
        //Arrange:
        Inventory inventory = new Inventory(5, 5);
        InventoryItemAdder inventoryItemAdder = new InventoryItemAdder(inventory);
        ItemEquipper itemEquipper = new ItemEquipper(inventory);
        InventoryItemStatsObserver observer = new InventoryItemStatsObserver(_player, itemEquipper);
        observer.Initialize();
        
        Item item = new Item { Title = "Shield", Size = new Vector2Int(2,3)};
        EquipableComponent equipableComponent = new EquipableComponent{isEquipped = true, type = "Armor"};
        ArmorComponent armorComponent = new ArmorComponent();
        item.AddComponent(equipableComponent);
        item.AddComponent(armorComponent);
        
        inventoryItemAdder.AddItem(item, new Vector2Int(0, 0));
        
        //Act:
        bool success1 = itemEquipper.Equip(new Vector2Int(0, 0));
        
        //Assert:
        Assert.AreEqual(1,_player.armor);
        Assert.IsFalse(success1);

        observer.Dispose();
    }
}
