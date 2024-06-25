using Sirenix.OdinInspector;
using UnityEngine;
using Equipment.Scripts;
using Zenject;

namespace GameEngine
{
    public sealed class InventoryDebug : MonoBehaviour
    {
        [Inject]
        private InventoryItemAdder _inventoryItemAdder;

        [Inject]
        private InventoryItemConsumer _itemConsumer;

        [Inject]
        private ItemEquipper _itemEquipper;

        [Button]
        public void AddItem(ItemConfig config, Vector2Int position)
        {
            Item item = config.InstantiateItem();
            bool success = _inventoryItemAdder.AddItem(item, position);
            Debug.Log($"Item added {success}");
        }

        [Button]
        public void ConsumeItem(Vector2Int position)
        {
            bool success = _itemConsumer.Consume(position);
            Debug.Log($"Item consumed {success}");
        }
        
        [Button]
        public void EquipItem(Vector2Int position)
        {
            bool success = _itemEquipper.Equip(position);
            Debug.Log($"Item equipped {success}");
        }    
        
        [Button]
        public void UnequipItem(Vector2Int position)
        {
            bool success = _itemEquipper.Unequip(position);
            Debug.Log($"Item unequipped {success}");
        }
    }
}