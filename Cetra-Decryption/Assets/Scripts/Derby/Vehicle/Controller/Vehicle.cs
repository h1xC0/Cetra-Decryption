using System.Collections.Generic;
using UnityEngine;

namespace Derby.Vehicle.Controller
{
    public class Vehicle : MonoBehaviour, IVehicle
    {
        [SerializeField] private List<VehicleSpring> _springs;
        [SerializeField] private Rigidbody _vehicleBody;
        [SerializeField] private float _multiplier;

        private Vector3 GetInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var mainCamera = Camera.main.transform;
            var direction = mainCamera.forward * vertical + mainCamera.right * horizontal;

            return direction;
        }

        private void Update()
        {
            var input = GetInput();
            _vehicleBody.velocity = input * _multiplier;
            WheelsSteering(input);
        }

        private void WheelsSteering(Vector3 input)
        {
            foreach (var spring in _springs)
            {
                RaycastHit hit;
                if (Physics.Raycast(spring.transform.position, -transform.up, out hit, spring.MaxDistance))
                {
                    _vehicleBody.AddForceAtPosition(spring.MaxForce * Time.fixedDeltaTime * transform.up * (spring.MaxDistance - hit.distance) / spring.MaxDistance, spring.transform.position);
                }
            }
        }
    }
}