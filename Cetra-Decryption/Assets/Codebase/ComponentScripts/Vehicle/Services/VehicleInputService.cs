using Codebase.ComponentScripts.VehicleInput.Controller;
using Codebase.ComponentScripts.VehicleInput.View;
using Codebase.StaticData;
using UnityEngine;
using Zenject;

namespace Codebase.ComponentScripts.Vehicle.Services
{
    public class VehicleInputService : IVehicleInputService
    {
        private Vector3 _direction;
        public Vector3 Direction => _direction;

        private IVehicleInputView _vehicleInputView;
        private IInstantiator _instantiator;
        
        public VehicleInputService(IInstantiator instantiator)
        {
            _instantiator = instantiator;

            _vehicleInputView = _instantiator.InstantiatePrefabResourceForComponent<IVehicleInputView>(ResourcesInfo.VehicleInputInfo.Path);
        }
        
        
        public void HandleInput(Transform cameraTransform)
        {
            var inputAxis = _vehicleInputView.ClassicInput();
            _direction = cameraTransform.forward * inputAxis.y + cameraTransform.right * inputAxis.y;
        }
    }
}
