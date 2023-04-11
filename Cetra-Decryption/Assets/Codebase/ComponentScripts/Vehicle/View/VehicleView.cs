using System.Collections.Generic;
using System.Linq;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.MVC;
using Codebase.Systems.UnityLifecycle.Ticks;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleView : BaseView, IVehicleView, IFixedUpdateTick
    {
        [SerializeField] private List<SpringView> _springs;
        [SerializeField] private List<Transform> _wheels;

        [SerializeField] private Rigidbody _body;

        public override void Construct()
        {
            
        }

        public void SetupSprings(IEnumerable<VehicleSpringModel> springs)
        {
            //TODO : Instntiate spring view
            var springsArr = springs.ToArray();
            for (int i = 0; i < _springs.Count; i++)
            {
                _springs[i].Initialize(springsArr[i]);
            }
        }

        //TODO: move this code to input service!
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
        //

        public void FixedUpdateTick()
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