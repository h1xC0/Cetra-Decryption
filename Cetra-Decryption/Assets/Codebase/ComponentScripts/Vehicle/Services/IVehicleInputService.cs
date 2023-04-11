using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.Services
{
    public interface IVehicleInputService
    {
        public Vector3 Direction { get; }
        public void HandleInput(Transform cameraTransform);
    }
}