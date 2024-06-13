using Zenject;

namespace GameEngine
{
    public sealed class InventorySystemInstaller : Installer<InventorySystemInstaller>
    {
        public override void InstallBindings()
        {
            this.Container.Bind<Inventory>().FromInstance(new Inventory(10, 10)).AsSingle().NonLazy();
            this.Container.Bind<InventoryItemAdder>().AsSingle().NonLazy();
            this.Container.Bind<InventoryItemRemover>().AsSingle().NonLazy();
            this.Container.Bind<InventoryItemConsumer>().AsSingle().NonLazy();
        }
    }
}