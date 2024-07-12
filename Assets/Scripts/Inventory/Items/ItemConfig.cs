using UnityEngine;

namespace GameEngine
{
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "Inventory/New ItemConfig"
    )]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeField]
        private Item item; //prefab

        public Item InstantiateItem()
        {
            return item.Clone();
        }
    }
}