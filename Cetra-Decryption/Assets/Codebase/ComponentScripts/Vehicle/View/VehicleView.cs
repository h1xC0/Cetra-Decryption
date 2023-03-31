using System;
using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    public abstract class VehicleView : BaseView, IVehicleView
    {
        public string Id => Guid.NewGuid().ToString();

        [SerializeField] private List<Transform> _springs;
        [SerializeField] private List<Transform> _wheels;
        [SerializeField] private Dictionary<Transform, Transform> _points;
        [SerializeField] private Rigidbody _vehicleBody;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _wheelRadius = 0.85f;
        [SerializeField] private float dampingFactor;

        public void Initialize()
        {
            for (int i = 0; i < _springs.Count; i++)
            {
                _points.Add(_springs[i], _wheels[i]);
            }
        }
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
            SpringSuspension(_maxDistance);
        }

        private void SpringSuspension(float maxDistance)
        {
            foreach (var spring in _springs)
            {
                Transform wheel;
                bool found = _points.TryGetValue(spring, out wheel);
                
                RaycastHit hit;
                if (Physics.Raycast(spring.transform.position, -transform.up, out hit, maxDistance))
                {
                    float damping = Vector3.Dot(_vehicleBody.GetPointVelocity(spring.transform.position),spring.transform.up);
                    
                    _vehicleBody.AddForceAtPosition(
                        _maxForce * Time.fixedDeltaTime * transform.up *
                        Mathf.Max(((_maxDistance - hit.distance + _wheelRadius) / _maxDistance - damping), 0),
                        spring.transform.position);
                    if (found)
                    {
                        wheel.localPosition = new Vector3(wheel.localPosition.x, (_wheelRadius / hit.distance) / wheel.lossyScale.y, wheel.localPosition.z);
                    }
                }
                else if (found)
                {
                    
                }
            }
        }

        public void DestroyView()
        {
            
        }
    }
}