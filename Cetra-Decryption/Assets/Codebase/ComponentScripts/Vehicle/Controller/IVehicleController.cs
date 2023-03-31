using System;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public interface IVehicleController<out TView> : IDisposable, IPlayerVehicle
        where TView : IVehicleView
    {
        
    }
}