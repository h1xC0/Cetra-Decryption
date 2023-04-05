using System;
using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.SO;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleView : BaseView, IVehicleView
    {
        public string Id => Guid.NewGuid().ToString();

        [SerializeField] private VehicleModelData _vehicleModelData;
        
        [SerializeField] private List<Transform> _springs;
        [SerializeField] private List<WheelView> _wheels;

        private Dictionary<Transform, WheelView> _points;
        private Rigidbody _body;
        
        protected override void Setup()
        {
            _points = new Dictionary<Transform, WheelView>();
            _body = GetComponent<Rigidbody>();
            
            for (int i = 0; i < _springs.Count; i++)
            {
                _points.Add(_springs[i], _wheels[i]);
            }
            
            for (int i = 0; i < _wheels.Count; i++)
            {
                var wheelData = _vehicleModelData.Wheels[i];
                _wheels[i].Setup(wheelData.RestLength, wheelData.SpringTravel, wheelData.SpringStiffness, wheelData.SpringStiffness, wheelData.DamperStiffness);
            }
        }
        
        public override void FixedTick()
        {
            foreach (var wheel in _wheels)
            {
                wheel.WheelSuspension(_body);
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

        
        public void DestroyView()
        {
            
        }
    }
}