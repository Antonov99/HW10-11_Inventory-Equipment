using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class HealingComponent : IItemComponent
    {
        [field: SerializeField]
        public int HealingPoints { get; set; } = 2;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}