using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.SO;
using Codebase.StaticData;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Payloads;
using Codebase.Systems.CommandSystem.Signals;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class BootstrapMonoInstaller : MonoInstaller
    {
        [SerializeField] private VehicleModelData _vehicleModelData;
        
        private ICommandDispatcher _commandDispatcher;

        public override void InstallBindings()
        { 
            Container.Install<ServicesInstaller>(); 
            Container.Install<BootstrapInstaller>();
            
            Container.Bind<IVehicleModel>()
                .FromInstance(_vehicleModelData.ToModel())
                .AsSingle();
            
            _commandDispatcher = Container.Resolve<ICommandDispatcher>();
        }

        private void Awake()
        {
            _commandDispatcher.Dispatch<LoadGameSceneSignal>(new SceneNamePayload(SceneNames.Game));
        }
    }
}