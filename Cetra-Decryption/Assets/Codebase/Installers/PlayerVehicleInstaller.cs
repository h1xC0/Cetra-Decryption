using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.SO;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Signals;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class PlayerVehicleInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSpawnPoint _spawnPoint;

        private DiContainer _container;
        
        public override void InstallBindings()
        {
            _container = Container.AncestorContainers[0];
            
            _container.Bind<PlayerSpawnPoint>()
                .FromInstance(_spawnPoint)
                .AsSingle();
        }
    }
}