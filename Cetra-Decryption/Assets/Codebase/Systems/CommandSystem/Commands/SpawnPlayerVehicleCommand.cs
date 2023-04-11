using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.CommandSystem.Payloads;
using Zenject;

namespace Codebase.Systems.CommandSystem.Commands
{
    public class SpawnPlayerVehicleCommand : Command
    {
        private readonly IVehicleFactory _vehicleFactory;
        private readonly IVehicleModel _model;
        
        public SpawnPlayerVehicleCommand(
            IInstantiator instantiator,
            PlayerSpawnPoint playerSpawnPoint,
            IVehicleModel vehicleModel)
        {
            _vehicleFactory = new VehicleFactory(instantiator, playerSpawnPoint);
            _model = vehicleModel;
        }
        
        protected override void Execute(ICommandPayload payload)
        {
            Retain();

            var playerVehicle = _vehicleFactory.GeneratePlayerVehicle(_model);

            Release();
        }
    }
}