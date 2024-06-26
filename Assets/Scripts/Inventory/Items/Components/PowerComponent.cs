using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class PowerComponent : IItemComponent
    {
        public int power => _power;
        
        [SerializeField]
        private int _power;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}