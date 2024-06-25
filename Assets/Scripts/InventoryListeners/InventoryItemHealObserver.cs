using System;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class InventoryItemHealObserver : IInitializable, IDisposable
    {
        private readonly InventoryItemConsumer _itemConsumer;
        private readonly Player _player;

        public InventoryItemHealObserver(InventoryItemConsumer itemConsumer, Player player)
        {
            _itemConsumer = itemConsumer;
            _player = player;
        }

        public void Initialize()
        {
            _itemConsumer.OnItemConsumed += this.OnItemConsumed;
        }

        public void Dispose()
        {
            _itemConsumer.OnItemConsumed -= this.OnItemConsumed;
        }

        private void OnItemConsumed(Item item)
        {
            if (item.TryGetComponent(out HealingComponent healingComponent))
            {
                _player.health += healingComponent.HealingPoints;
                Debug.Log($"HEALING: +{healingComponent.HealingPoints}");
            }
        }
    }
}