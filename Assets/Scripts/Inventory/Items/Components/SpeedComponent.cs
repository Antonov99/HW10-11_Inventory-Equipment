using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class SpeedComponent : IItemComponent
    {
        public int speed => _speed;
        
        [SerializeField]
        private int _speed;
        
        public IItemComponent Clone()
        {
            return this;
        }
    }
}