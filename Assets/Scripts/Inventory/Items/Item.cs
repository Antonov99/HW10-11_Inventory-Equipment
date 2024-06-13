using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class Item
    {
        [field: SerializeField]
        public string Title { get; set;}

        [field: SerializeField]
        public string Description { get; set;}

        [field: SerializeField]
        public Sprite Icon { get; set;}

        [field: SerializeField]
        public Vector2Int Size { get; set;}

        [field: SerializeField]
        public ItemFlags Flags { get; set; }

        [SerializeReference]
        private IItemComponent[] components;

        public bool TryGetComponent<T>(out T component)
        {
            for (int i = 0, count = this.components.Length; i < count; i++)
            {
                if (this.components[i] is T tComponent)
                {
                    component = tComponent;
                    return true;
                }
            }

            component = default;
            return false;
        }

        public Item Clone()
        {
            return new Item
            {
                Title = this.Title,
                Description = this.Description,
                Icon = this.Icon,
                Size = this.Size,
                Flags = this.Flags,
                components = this.CloneComponents()
            };
        }

        private IItemComponent[] CloneComponents()
        {
            int length = this.components.Length;
            var result = new IItemComponent[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = this.components[i].Clone();
            }

            return result;
        }
    }
}