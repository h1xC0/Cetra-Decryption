using Codebase.ComponentScripts.SpawnPoints;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.View;
using Codebase.StaticData;
using Codebase.Systems.MVC;
using UniRx;
using Zenject;

namespace Codebase.ComponentScripts.Vehicle
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISpawnPoint _playerSpawnPoint;
        private readonly CompositeDisposable _compositeDisposable = new();

        public VehicleFactory(DiContainer container, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _playerSpawnPoint = container.Resolve<PlayerSpawnPoint>();
        }

        public IVehicle GeneratePlayerVehicle(IVehicleModel model)
        {
            var vehicleView = _instantiator
                .InstantiatePrefabResourceForComponent<SimpleCarView>(ResourcesInfo.PlayerVehicleInfo.Path,
                    _playerSpawnPoint.GetSpawnParent());

            // TODO: change place of disposing vehicle controllers
            var controller = new SimpleCarController(vehicleView).AddTo(_compositeDisposable);
            return controller;
        }

        public IVehicle GenerateAiVehicle()
        {
            return null; // Connect Chat-GPT to control vehicle brain
        }
    }
}