using Codebase.Enums;
using Codebase.Systems.MVC;
using UnityEngine;

namespace Codebase.ComponentScripts.VehicleInput.Controller
{
    public interface IVehicleInputView : IView
    {
        Vector2 ClassicInput();
        void SetInputType(SharedInputType sharedInputType);
    }
}