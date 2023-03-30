using System.Collections.Generic;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class Vehicle : MonoBehaviour, IVehicle
    {
        [SerializeField] private List<VehicleSpring> _springs;
        [SerializeField] private Rigidbody _vehicleBody;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _maxDistance;
        private Vector3 GetInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var mainCamera = Camera.main.transform;
            var direction = mainCamera.forward * vertical + mainCamera.right * horizontal;

            return direction;
        }

        private void FixedUpdate()
        {
            var input = GetInput();
            WheelsSteering(input);
        }

        private void WheelsSteering(Vector3 input)
        {
            foreach (var spring in _springs)
            {
                RaycastHit hit;
                if (Physics.Raycast(spring.transform.position, -transform.up, out hit, spring.MaxDistance))
                {
                    _vehicleBody.AddForceAtPosition(_maxForce * Time.fixedDeltaTime * transform.up * (_maxDistance - hit.distance) / _maxDistance, spring.transform.position);
                }
            }
        }
    }
}