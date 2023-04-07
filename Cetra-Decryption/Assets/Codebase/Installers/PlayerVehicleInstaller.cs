using Codebase.ComponentScripts.VehicleInput.Model;
using Codebase.ComponentScripts.SpawnPoints;
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