using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public sealed class Player
    {
        [field: SerializeField]
        public int health { get; set; } = 5;

        [field: SerializeField] 
        public int power { get; set; } = 1;

        [field: SerializeField] 
        public int speed { get; set; } = 1;
        
        [field: SerializeField] 
        public int armor { get; set; } = 1;
    }
}