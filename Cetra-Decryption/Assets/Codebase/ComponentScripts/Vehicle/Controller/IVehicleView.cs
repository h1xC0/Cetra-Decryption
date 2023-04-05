using Codebase.Systems.MVC;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public interface IVehicleView : IView
    {
        string Id { get; }
        
        //TODO: Other data like view static info or base functional for vehicle views
        
        void DestroyView();
    }
}