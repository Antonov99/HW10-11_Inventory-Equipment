using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class EquippableComponent:IItemComponent
    {
        public bool isEquipped;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}