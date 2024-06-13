using UnityEngine;

namespace GameEngine
{
    public sealed class Player : MonoBehaviour
    {
        [field: SerializeField]
        public int Health { get; set; } = 5;
        
        [field: SerializeField]
        public int Damage { get; set; }
        
        [field: SerializeField]
        public int Speed { get;  set; }
    }
}