using Codebase.StaticData;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Payloads;
using Codebase.Systems.CommandSystem.Signals;
using Codebase.Systems.UnityLifecycle;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapMonoInstaller : MonoInstaller
    {
        [SerializeField] private UnityLifecycleHandler lifecycleHandler;
        public override void InstallBindings()
        { 
            Container
                .Bind<IUnityLifecycleHandler>()
                .To<UnityLifecycleHandler>()
                .FromComponentInNewPrefab(lifecycleHandler)
                .AsSingle();
            
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