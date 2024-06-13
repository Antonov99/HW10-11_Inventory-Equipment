using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class InventoryDebug : MonoBehaviour
    {
        [Inject]
        private InventoryItemAdder _inventoryItemAdder;

        [Inject]
        private InventoryItemConsumer _itemConsumer;

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
    }
}