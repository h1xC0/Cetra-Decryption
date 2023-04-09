using System;
using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleView : BaseView, IVehicleView
    {
        public string Id => Guid.NewGuid().ToString();

        [SerializeField] private List<SpringView> _springs;
        [SerializeField] private List<Transform> _wheels;

        [SerializeField] private Rigidbody _body;

        public void Initialize(VehicleModel model)
        {
            //TODO : Instntiate spring view
            for (int i = 0; i < _springs.Count; i++)
            {
                _springs[i].Initialize(model.SpringModels[i]);
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
        
        public void FixedUpdate()
        {
            RefreshVehicleComponents();
        }

        private void RefreshVehicleComponents()
        {
            foreach (var spring in _springs)
            {
                spring.WheelSuspension(_body);
            }
        }

        
        public void DestroyView()
        {
            
        }
    }
}