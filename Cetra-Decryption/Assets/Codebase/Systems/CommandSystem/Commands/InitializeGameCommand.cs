using Codebase.Systems.CommandSystem.Payloads;
using Derby;
using Zenject;

namespace Codebase.Systems.CommandSystem.Commands
{
    public class InitializeGameCommand : Command
    {
        private readonly IVehicleFactory _vehicleFactory;
        
        public InitializeGameCommand(IInstantiator instantiator, 
            DiContainer container)
        {
            _vehicleFactory = new VehicleFactory(container, instantiator);
        }
        
        protected override void Execute(ICommandPayload payload)
        {
            Retain();

            _vehicleFactory.GeneratePlayerVehicle();
            
            Release();
        }
    }
}