using System;
using Equipment.Scripts;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    [UsedImplicitly]
    public sealed class InventoryItemStatsObserver : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly ItemEquipper _itemEquipper;

        public InventoryItemStatsObserver(Player player, ItemEquipper itemEquipper)
        {
            _player = player;
            _itemEquipper = itemEquipper;
        }

        public void Initialize()
        {
            _itemEquipper.onItemEquiped += OnItemEquiped;
            _itemEquipper.onItemUnequiped += OnItemUnequiped;
        }

        public void Dispose()
        {
            _itemEquipper.onItemEquiped -= OnItemEquiped;
            _itemEquipper.onItemUnequiped -= OnItemUnequiped;
        }

        private void OnItemEquiped(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.power += powerComponent.power;
                Debug.Log($"Added Power: {powerComponent.power} ");
            }
            
            if (item.TryGetComponent(out ArmorComponent armorComponent))
            {
                _player.armor += armorComponent.armor;
                Debug.Log($"Added Armor: {armorComponent.armor} ");
            }
            
            if (item.TryGetComponent(out SpeedComponent speedComponent))
            {
                _player.speed += speedComponent.speed;
                Debug.Log($"Added Speed: {speedComponent.speed} ");
            }
        }

        private void OnItemUnequiped(Item item)
        {
            if (item.TryGetComponent(out PowerComponent powerComponent))
            {
                _player.power -= powerComponent.power;
                Debug.Log($"Removed Power: {powerComponent.power} ");
            }
            
            if (item.TryGetComponent(out ArmorComponent armorComponent))
            {
                _player.armor -= armorComponent.armor;
                Debug.Log($"Removed Armor: {armorComponent.armor} ");
            }
            
            if (item.TryGetComponent(out SpeedComponent speedComponent))
            {
                _player.speed -= speedComponent.speed;
                Debug.Log($"Removed Speed: {speedComponent.speed} ");
            }
        }
    }
}