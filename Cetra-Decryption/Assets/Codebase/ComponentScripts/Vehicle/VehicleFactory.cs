using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.View;
using Codebase.StaticData;
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

        public IVehicle GeneratePlayerVehicle(IVehicleModel model)
        {
            var vehicleView = _instantiator
                .InstantiatePrefabResourceForComponent<VehicleView>(ResourcesInfo.PlayerVehicleInfo.Path,
                    _playerSpawnPoint.GetSpawnParent());

            object[] viewModelArgs = {vehicleView, model};

            return _instantiator
                .Instantiate<VehicleController>(viewModelArgs);
        }

        public IVehicle GenerateAiVehicle()
        {
            return null;
        }
    }
}