using Codebase.StaticData;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Payloads;
using Codebase.Systems.CommandSystem.Signals;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        { 
            Container.Install<ServicesInstaller>(); 
            Container.Install<BootstrapInstaller>();
        }

        public void Awake()
        {
            var commandDispatcher = Container.Resolve<ICommandDispatcher>();
            commandDispatcher.Dispatch<LoadGameSceneSignal>( new SceneNamePayload(SceneNames.Game));
        }
    }
}