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
            InventorySystemInstaller.Install(this.Container);
            this.Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            
            this.Container.BindInterfacesTo<InventoryItemPowerObserver>().AsCached().NonLazy();
            this.Container.BindInterfacesTo<InventoryItemHealObserver>().AsCached().NonLazy();
        }
    }
}