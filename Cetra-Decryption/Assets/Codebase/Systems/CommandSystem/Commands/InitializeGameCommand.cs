using Codebase.ComponentScripts.Vehicle;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.CommandSystem.Payloads;
using Zenject;

namespace Codebase.Systems.CommandSystem.Commands
{
    public class InitializeGameCommand : Command
    {
        private readonly IVehicleFactory _vehicleFactory;
        private readonly DiContainer _container;
        private readonly IVehicleModel _model;
        
        public InitializeGameCommand(
            IInstantiator instantiator, 
            DiContainer container,
            IVehicleModel vehicleModel)
        {
            _vehicleFactory = new VehicleFactory(container, instantiator);
            _container = container;
            _model = vehicleModel;
        }
        
        protected override void Execute(ICommandPayload payload)
        {
            Retain();

            var playerVehicle = _vehicleFactory.GeneratePlayerVehicle(_model);

            _container
                .Bind<IPlayerVehicle>()
                .FromInstance(playerVehicle)
                .AsSingle()
                .NonLazy();

            Release();
        }
    }
}