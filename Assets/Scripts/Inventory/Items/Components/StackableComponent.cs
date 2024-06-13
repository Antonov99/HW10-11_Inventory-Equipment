using System;

namespace GameEngine
{
    [Serializable]
    public sealed class StackableComponent : IItemComponent
    {
        public int current;
        public int max;
        
        public IItemComponent Clone()
        {
            return new StackableComponent
            {
                current = this.current,
                max = this.max
            };
        }
    }
}