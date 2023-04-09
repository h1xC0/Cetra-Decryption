using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.SO;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Signals;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class GameplayMonoInstaller : MonoInstaller
    {
        [SerializeField] private VehicleModelData _vehicleModelData;
        [SerializeField] private PlayerSpawnPoint _spawnPoint;

        public override void InstallBindings()
        {
            Container.Install<GameplayInstaller>();
            
            Container.BindInstance(_spawnPoint)
                .AsSingle();

            Container.Bind<IVehicleModel>()
                .FromInstance(_vehicleModelData.ToModel())
                .AsSingle();
        }

        private void Awake()
        {
            var commandDispatcher = Container.Resolve<ICommandDispatcher>();
            commandDispatcher.Dispatch<InitializeGameSignal>();
        }
    }
}