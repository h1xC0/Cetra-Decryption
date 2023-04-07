using Codebase.ComponentScripts.VehicleInput.Controller;
using Codebase.Enums;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.VehicleInput.View
{
    public class VehicleInputView : BaseView, IVehicleInputView
    {
       [SerializeField] private SharedInputType _sharedInputType;
        
        public Vector2 ClassicInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector2(horizontal, vertical);
        }

        public void SetInputType(SharedInputType sharedInputType)
        {
            _sharedInputType = sharedInputType;
        }
    }
}