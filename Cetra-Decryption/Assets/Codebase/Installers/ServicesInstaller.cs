using Codebase.Systems.CommandSystem;
using Codebase.Systems.EventBroker;
using Zenject;

namespace Codebase.Installers
{
    public class ServicesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CommandBinder>().AsSingle().CopyIntoAllSubContainers();
            Container.BindInterfacesTo<EventBrokerService>().FromNew().AsCached();
            Container.BindInterfacesTo<CommandDispatcher>().FromNew().AsCached();
        }
    }
}