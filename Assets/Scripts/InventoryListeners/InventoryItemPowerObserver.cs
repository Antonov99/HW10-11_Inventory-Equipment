using System;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    //GRASP CONTROLLER 
    public sealed class InventoryItemPowerObserver : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly Inventory _inventory;

        public InventoryItemPowerObserver(Player player, Inventory inventory)
        {
            _player = player;
            _inventory = inventory;
        }

        public void Initialize()
        {
            _inventory.OnItemAdded += this.OnItemAdded;
            _inventory.OnItemRemoved += this.OnItemRemoved;
        }

        public void Dispose()
        {
            _inventory.OnItemAdded -= this.OnItemAdded;
            _inventory.OnItemRemoved -= this.OnItemRemoved;
        }

        private void OnItemAdded(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.Damage += powerComponent.Power;
                Debug.Log($"Added Power: {powerComponent.Power} ");
            }
        }

        private void OnItemRemoved(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.Damage -= powerComponent.Power;
                Debug.Log($"Removed Power: {powerComponent.Power} ");
            }
        }
    }
}