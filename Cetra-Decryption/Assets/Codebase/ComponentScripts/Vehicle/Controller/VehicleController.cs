using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.MVC;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class VehicleController<TView> : BaseController<TView>, IPlayerVehicle where TView : IView
    {
        public VehicleController(TView viewContract, IVehicleModel model) : base(viewContract)
        {
        }
    }
}