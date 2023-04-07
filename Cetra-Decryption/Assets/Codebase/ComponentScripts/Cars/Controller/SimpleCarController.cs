using Codebase.ComponentScripts.Vehicle.Controller;

namespace Codebase.ComponentScripts.Cars.Controller
{
    public class SimpleCarController : VehicleController<ISimpleCarView>
    {
        public SimpleCarController(ISimpleCarView view) : base(view)
        {
        }
        
    }
}