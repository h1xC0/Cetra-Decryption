using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.View
{
    public class SpringView : VehicleViewComponent
    {
        // Suspension (serializable)
        private float _restLength;
        private float _springTravel;
        private float _springStiffness;
        private float _damperStiffness;
        
        private float _minLength;
        private float _maxLength;
        private float _lastLength;
        private float _springLength;
        private float _springVelocity;
        private float _springForce;
        private float _damperForce;

        private Vector3 _suspensionForce;

        private float _wheelRadius;
        private float _wheelOffset;

        private Rigidbody _rigidbody;
        private Transform _wheel;

        public void Setup(float wheelRadius, float wheelOffset, float restLength, float springTravel, float springStiffness, float damperStiffness)
        {
            _wheelRadius = wheelRadius;
            _wheelOffset = wheelOffset;
            
            _restLength = restLength;
            _springTravel = springTravel;
            _springStiffness = springStiffness;
            _damperStiffness = damperStiffness;
            
            _minLength = _restLength - _springTravel;
            _maxLength = _restLength + _springTravel;

            _wheel = transform.GetChild(0);
        }

        public void WheelSuspension(Rigidbody vehicleBody)
        {
            var wheelLocalPosition = _wheel.transform.localPosition;

            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, _maxLength + _wheelRadius))
            {
                _lastLength = _springLength;
                _springLength = hit.distance - _wheelRadius;
                _springLength = Mathf.Clamp(_springLength, _minLength, _maxLength);
                _springVelocity = (_lastLength - _springLength) / Time.fixedDeltaTime;
                _springForce = _springStiffness * (_restLength - _springLength);
                _damperForce = _damperStiffness * _springVelocity;
                    
                _suspensionForce = (_springForce + _damperForce) * transform.up;
                
                vehicleBody.AddForceAtPosition(_suspensionForce, hit.point);

                wheelLocalPosition = new Vector3(wheelLocalPosition.x,
                    _wheelOffset / (_wheelRadius / hit.distance), wheelLocalPosition.z);

                //Debug.Log($"Hit collider: <color=red>{hit.collider.name}</color>");
            }
            else
            {
                wheelLocalPosition = new Vector3(wheelLocalPosition.x,
                    _wheelOffset / (_wheelRadius - _restLength), wheelLocalPosition.z);
            }
            
            _wheel.transform.localPosition = wheelLocalPosition;
            Debug.DrawRay(transform.position, -transform.up * _springLength, Color.magenta);
        }
    }
}