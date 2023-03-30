using Codebase.ComponentScripts.Vehicle;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.CommandSystem.Payloads;
using Zenject;

namespace Codebase.Systems.CommandSystem.Commands
{
    public class InitializeGameCommand : Command
    {
        private readonly IVehicleFactory _vehicleFactory;
        
        public InitializeGameCommand(IInstantiator instantiator, 
            DiContainer container,
            IVehicleModel vehicleModel)
        {
            _vehicleFactory = new VehicleFactory(container, instantiator);
        }
        
        protected override void Execute(ICommandPayload payload)
        {
            Retain();

            var playerVehicle = _vehicleFactory.GeneratePlayerVehicle();

            Release();
        }
    }
}