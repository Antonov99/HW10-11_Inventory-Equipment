using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class ArmorComponent : IItemComponent
    {
        public int armor => _armor;
        
        [SerializeField]
        private int _armor=2;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}