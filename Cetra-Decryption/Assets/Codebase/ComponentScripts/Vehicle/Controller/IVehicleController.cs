using System;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public interface IVehicleController<out TView> : IDisposable, IVehicle
        where TView : IVehicleView
    {
        
    }
}