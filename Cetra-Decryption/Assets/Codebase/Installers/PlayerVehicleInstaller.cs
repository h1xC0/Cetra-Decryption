using Codebase.ComponentScripts.SpawnPoints;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Signals;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class PlayerVehicleInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSpawnPoint _spawnPoint;

        private ICommandDispatcher _commandDispatcher;
        
        public override void InstallBindings()
        {
            Container.AncestorContainers[0].Bind<PlayerSpawnPoint>()
                .FromInstance(_spawnPoint)
                .AsSingle();
        }
    }
}