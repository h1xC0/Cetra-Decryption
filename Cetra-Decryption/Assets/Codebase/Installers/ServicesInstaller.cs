using Codebase.Systems.CommandSystem;
using Codebase.Systems.EventBroker;
using Zenject;

namespace Codebase.Installers
{
    public class ServicesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EventBrokerService>().AsSingle();
            Container.BindInterfacesTo<CommandDispatcher>().AsSingle();
        }
    }
}