using Codebase.StaticData;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Commands;
using Codebase.Systems.CommandSystem.Payloads;
using Codebase.Systems.CommandSystem.Signals;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapMonoInstaller : MonoInstaller
    {
        private ICommandDispatcher _commandDispatcher;
        
        public override void InstallBindings()
        { 
            Container.Install<ServicesInstaller>(); 
            Container.Install<BootstrapInstaller>();
            _commandDispatcher = Container.Resolve<ICommandDispatcher>();
        }

        private void Awake()
        {
            _commandDispatcher.Dispatch<LoadMainMenuSignal>(new SceneNamePayload(SceneNames.Menu));
        }
    }
}