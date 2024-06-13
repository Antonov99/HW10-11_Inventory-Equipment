using System;
using UnityEngine;

namespace GameEngine
{
    // [MovedFrom(true, null, null, "StrengthComponent")]
    [Serializable]
    public sealed class PowerComponent : IItemComponent
    {
        public int Power => this.power;
        
        [SerializeField]
        private int power;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}