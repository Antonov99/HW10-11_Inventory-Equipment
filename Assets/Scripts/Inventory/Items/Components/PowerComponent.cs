using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class PowerComponent : IItemComponent
    {
        public int power => _power;
        
        [SerializeField]
        private int _power=3;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}