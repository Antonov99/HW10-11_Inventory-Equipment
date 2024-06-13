using System;

namespace GameEngine
{
    [Flags]
    public enum ItemFlags
    {
        NONE = 0, //0000
        CONSUMABLE = 1, //0001
        EQUIPPABLE = 2, //0010 -> //0011
        EFFECTIBLE = 4,
        STACKABLE = 8
    }
}