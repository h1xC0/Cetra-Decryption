using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.View;
using Codebase.StaticData;
using Codebase.Systems.MVC;
using Zenject;

namespace Codebase.ComponentScripts.Vehicle
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISpawnPoint _playerSpawnPoint;

        public VehicleFactory(IInstantiator instantiator, PlayerSpawnPoint playerSpawnPoint)
        {
            _instantiator = instantiator;
            _playerSpawnPoint = playerSpawnPoint;
        }

        public IPlayerVehicle GeneratePlayerVehicle(IVehicleModel model)
        {
            var vehicleView = _instantiator
                .InstantiatePrefabResourceForComponent<VehicleView>(ResourcesInfo.PlayerVehicleInfo.Path,
                    _playerSpawnPoint.GetSpawnParent());

            var controller = new VehicleController<IView>(vehicleView, model);

            return controller;
        }

        public IVehicle GenerateAiVehicle()
        {
            return null;
        }
    }
}