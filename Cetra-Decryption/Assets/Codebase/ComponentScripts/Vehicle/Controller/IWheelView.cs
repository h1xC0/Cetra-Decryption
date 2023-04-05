using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public interface IWheelView
    {
        void Setup(float wheelRadius, float restLength, float springTravel, float springStiffness, float damperStiffness);
    }
}