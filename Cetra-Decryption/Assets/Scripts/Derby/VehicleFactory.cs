using Codebase.StaticData;
using Derby.Vehicle.Controller;
using SpawnPoints;
using Zenject;

namespace Derby
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISpawnPoint _playerSpawnPoint;
        private readonly DiContainer _container;

        public VehicleFactory(DiContainer container, IInstantiator instantiator)
        {
            _container = container;
            _instantiator = instantiator;
            _playerSpawnPoint = container.Resolve<PlayerSpawnPoint>();
        }

        public IVehicle GeneratePlayerVehicle()
        {
            var playerVehicle = _instantiator
                .InstantiatePrefabResourceForComponent<IVehicle>(ResourcesInfo.PlayerVehicleInfo.Path,
                    _playerSpawnPoint.GetSpawnParent());

            _container
                .Bind<IVehicle>()
                .FromInstance(playerVehicle)
                .AsSingle()
                .NonLazy();

            return playerVehicle;
        }

        public IVehicle GenerateAiVehicle()
        {
            return null;
        }
    }
}