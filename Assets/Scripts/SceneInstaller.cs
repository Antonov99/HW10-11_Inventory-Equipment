using Equipment.Scripts;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Player _player;
        
        public override void InstallBindings()
        {
            InventorySystemInstaller.Install(Container);
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            
            Container.BindInterfacesTo<InventoryItemStatsObserver>().AsCached().NonLazy();
            Container.BindInterfacesTo<InventoryItemHealObserver>().AsCached().NonLazy();

            Container.Bind<ItemEquipper>().AsSingle().NonLazy();
        }
    }
}