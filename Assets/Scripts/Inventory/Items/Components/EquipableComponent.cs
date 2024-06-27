using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class EquipableComponent:IItemComponent
    {
        public bool isEquipped;
        public string type;
        
        public IItemComponent Clone()
        {
            return new EquipableComponent
            {
                isEquipped = isEquipped,
                type = type
            };
        }
    }
}