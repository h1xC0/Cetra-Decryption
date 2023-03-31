using Codebase.ComponentScripts.Vehicle.Model;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class SimpleCarController : VehicleController<ISimpleCarView>
    {
        public SimpleCarController(ISimpleCarView view, IVehicleModel model) : base(view, model)
        {
            
        }

        protected override void Initialize()
        {
            View.Initialize();
        }
    }
}