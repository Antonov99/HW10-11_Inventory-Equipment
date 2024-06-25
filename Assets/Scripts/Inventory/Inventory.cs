using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine
{
    //Data
    public sealed class Inventory
    {

        public int Width { get; }
        public int Height { get; }

        public readonly Item[,] cells;
        public readonly Dictionary<Item, List<Vector2Int>> itemMap;

        public Inventory(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.cells = new Item[width, height];
            this.itemMap = new Dictionary<Item, List<Vector2Int>>();
        }
        
        public bool HasItem(int x, int y)
        {
            return this.cells[x, y] != null;
        }
        
        public bool HasItem(Vector2Int position)
        {
            return this.cells[position.x, position.y] != null;
        }

        public bool TryGetItem(Vector2Int position, out Item item)
        {
            int positionX = position.x;
            int positionY = position.y;
            
            if (positionX >= 0 && positionX < this.Width && positionY >= 0 && positionY < this.Height)
            {
                item = this.cells[positionX, positionY];
                return true;
            }

            item = default;
            return false;
        }
        
        public Item GetItem(Vector2Int position)
        {
            int positionX = position.x;
            int positionY = position.y;
            
            if (positionX >= 0 && positionX < this.Width && positionY >= 0 && positionY < this.Height)
            {
                return this.cells[positionX, positionY];
            }

            throw new Exception($"Invalid position {position}! Out off Range! ");
        }
    }
}