using GameEngine;
using NUnit.Framework;
using UnityEngine;

public sealed class InventoryTests
{
    [Test]
    public void ConsumeItem()
    {
        //Arrange:
        Inventory inventory = new Inventory(10, 10);
        InventoryItemAdder inventoryAdder = new InventoryItemAdder(inventory);
        InventoryItemRemover inventoryItemRemover = new InventoryItemRemover(inventory);
        InventoryItemConsumer itemConsumer = new InventoryItemConsumer(inventory, inventoryItemRemover);
        
        Item item = new Item
        {
            Title = "H",
            Size = new Vector2Int(1, 1),
            Flags = ItemFlags.CONSUMABLE
        };
        
        inventoryAdder.AddItem(item, new Vector2Int(2, 2));
        
        //Act:
        bool consumed = itemConsumer.Consume(item);

        //Assert:
        Assert.IsTrue(consumed);
        Assert.IsTrue(inventory.cells[2, 2] == null);
    }

    [Test]
    public void AddInventoryItem()
    {
        //Arrange:
        Inventory inventory = new Inventory(10, 10);
        InventoryItemAdder inventoryAdder = new InventoryItemAdder(inventory);
        Item item = new Item
        {
            Title = "T",
            Size = new Vector2Int(2, 2)
        };
        
        //Act:
        inventoryAdder.AddItem(item, new Vector2Int(2, 2));
        
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Item currentItem = inventory.cells[x, y];
                Debug.Log(currentItem != null ? $"{x}, {y} {currentItem.Title}" : $"{x}, {y} {0}");
            }
        }

        // //Assert:
        Assert.IsTrue(inventory.cells[2, 2] == item);
        Assert.IsTrue(inventory.cells[2, 3] == item);
        Assert.IsTrue(inventory.cells[3, 3] == item);
        Assert.IsTrue(inventory.cells[3, 2] == item);
    }
    
    [Test]
    public void AddInventoryItemFalse()
    {
        //Arrange:
        Inventory inventory = new Inventory(10, 10);
        InventoryItemAdder inventoryAdder = new InventoryItemAdder(inventory);
        Item item = new Item
        {
            Title = "T",
            Size = new Vector2Int(2, 2)
        };
        
        //Act:
        bool success = inventoryAdder.AddItem(item, new Vector2Int(9, 9));

        //Assert:
        Assert.IsFalse(success);
        Assert.IsTrue(inventory.cells[9, 9] == null);
    }
    
    [Test]
    public void AddInventoryItemOutOfBounds()
    {
        //Arrange:
        Inventory inventory = new Inventory(10, 10);
        InventoryItemAdder inventoryAdder = new InventoryItemAdder(inventory);
        Item item = new Item
        {
            Title = "T",
            Size = new Vector2Int(2, 2)
        };
        
        //Act:
        bool success = inventoryAdder.AddItem(item, new Vector2Int(10, 5));
    
        //Assert:
        Assert.IsFalse(success);
    }
}


