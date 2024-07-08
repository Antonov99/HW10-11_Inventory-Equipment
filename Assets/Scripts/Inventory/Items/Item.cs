using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class Item
    {
        [field: SerializeField]
        public string Title { get; set; }

        [field: SerializeField]
        public string Description { get; set; }

        [field: SerializeField]
        public Sprite Icon { get; set; }

        [field: SerializeField]
        public Vector2Int Size { get; set; }

        [field: SerializeField]
        public ItemFlags Flags { get; set; }

        [SerializeReference]
        public List<IItemComponent> Components = new List<IItemComponent>();

        public bool TryGetComponent<T>(out T component)
        {
            foreach (var comp in this.Components)
            {
                if (comp is T tComponent)
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
                Components = this.CloneComponents()
            };
        }

        private List<IItemComponent> CloneComponents()
        {
            var result = new List<IItemComponent>(this.Components.Count);

            foreach (var component in this.Components)
            {
                result.Add(component.Clone());
            }

            return result;
        }

        public void AddComponent(IItemComponent component)
        {
            Components.Add(component);
        }
    }
}