/*using System;
using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class VehicleView : BaseView, IVehicleView
    {
        public string Id => Guid.NewGuid().ToString();

        [SerializeField] private List<bool> _wheelsEnabled;
        [SerializeField] private List<Transform> _springs;
        [SerializeField] private List<Transform> _wheels;
        
        private Dictionary<Transform, Transform> _points;
        
        private Rigidbody _vehicleBody;
        private Collider _collider;
        
        [SerializeField] private float _maxForce;
        [SerializeField] private float _suspensionLength;
        [SerializeField] private float _wheelOffset;
        [SerializeField] private float _wheelRadius = 0.85f; // 40
        [SerializeField] private float dampingFactor;

        [SerializeField] private float _acceleration;

        protected override void Setup()
        {
            _points = new Dictionary<Transform, Transform>();
            _vehicleBody = GetComponent<Rigidbody>();
            _collider = _vehicleBody.GetComponent<Collider>();

            for (int i = 0; i < _springs.Count; i++)
            {
                _points.Add(_springs[i], _wheels[i]);
            }
        }
        private Vector3 GetInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (Camera.main != null)
            {
                var mainCamera = Camera.main.transform;
                var direction = mainCamera.forward * vertical + mainCamera.right * horizontal;

                return direction;
            }

            return Vector3.zero;
        }

        public override void FixedTick()
        {
            var input = GetInput();
            _vehicleBody.AddForce(input * _acceleration, ForceMode.Acceleration);
            SpringSuspension(_suspensionLength);
            WheelRotation();
        }

        private void WheelRotation()
        {
            foreach (var wheel in _wheels)
            {
                wheel.rotation = Quaternion.Euler(new Vector3(wheel.eulerAngles.x, wheel.eulerAngles.y, _vehicleBody.velocity.z * 100));
            }
        }

        private void SpringSuspension(float maxDistance)
        {
            for (var index = 0; index < _springs.Count; index++)
            {
                if (_wheelsEnabled[index] == false) continue;
                
                var spring = _springs[index];
                Transform wheel;
                bool found = _points.TryGetValue(spring, out wheel);

                RaycastHit hit;
                var springPosition = spring.transform.position;
                var wheelLocalPosition = wheel.localPosition;
                var springUpNormal = spring.transform.up;


                Debug.DrawRay(springPosition, -springUpNormal * maxDistance, Color.magenta);

                if (Physics.Raycast(springPosition, -transform.up, out hit, maxDistance))
                {
                    Debug.Log($"Collider: <color=red>{hit.collider.name}</color>");
                    float damping = dampingFactor *
                                    Vector3.Dot(_vehicleBody.GetPointVelocity(springPosition), springUpNormal);
                    // _vehicleBody.AddForceAtPosition(_maxForce * Time.fixedDeltaTime * transform.up * Mathf.Max(((_maxDistance - hit.distance + _wheelRadius) / _maxDistance - damping), 0), springPosition);
                    if(hit.collider != _collider)
                        _vehicleBody.AddForceAtPosition(
                        transform.up * (_maxForce * Time.fixedDeltaTime *
                                        Mathf.Max(
                                            ((maxDistance - hit.distance + _wheelRadius) / maxDistance - damping),
                                            0)), springPosition);

                    if (found)
                    {
                        wheelLocalPosition = new Vector3(wheelLocalPosition.x,
                            _wheelOffset / (_wheelRadius / hit.distance), wheelLocalPosition.z);
                    }
                }
                else if (found)
                {
                    wheelLocalPosition = new Vector3(wheelLocalPosition.x,
                        _wheelOffset / (_wheelRadius / maxDistance), wheelLocalPosition.z);
                }

                wheel.transform.localPosition = wheelLocalPosition;
            }
        }

        public void DestroyView()
        {
            
        }

        private void OnDrawGizmos()
        {
            foreach (var wheel in _wheels)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawWireSphere(wheel.transform.position, _wheelRadius);
            }
        }
    }
}*/