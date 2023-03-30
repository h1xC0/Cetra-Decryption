using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Derby.Vehicle.Controller
{
    public class Vehicle : MonoBehaviour, IVehicle
    {
        [SerializeField] private List<VehicleSpring> _springs;
        [SerializeField] private Rigidbody _vehicleBody;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _wheelRadius = 0.05f;
        [SerializeField] private float dampingFactor;
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
        }

        private void SpringSuspension()
        {
            foreach (var spring in _springs)
            {
                RaycastHit hit;
                if (Physics.Raycast(spring.transform.position, -transform.up, out hit, spring.MaxDistance))
                {
                    float damping = Vector3.Dot(_vehicleBody.GetPointVelocity(spring.transform.position),spring.transform.up);
                    _vehicleBody.AddForceAtPosition(_maxForce * Time.fixedDeltaTime * transform.up * Mathf.Max(((_maxDistance - hit.distance + _wheelRadius) / _maxDistance - damping), 0), spring.transform.position);
                }
            }
        }

        public void Dispose()
        {
            
        }

        public GameObject GameObject { get; }
    }
}