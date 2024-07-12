using Zenject;

namespace GameEngine
{
    public sealed class InventorySystemInstaller : Installer<InventorySystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Inventory>().FromInstance(new Inventory(10, 10)).AsSingle().NonLazy();
            Container.Bind<InventoryItemAdder>().AsSingle().NonLazy();
            Container.Bind<InventoryItemRemover>().AsSingle().NonLazy();
            Container.Bind<InventoryItemConsumer>().AsSingle().NonLazy();
        }
    }
}