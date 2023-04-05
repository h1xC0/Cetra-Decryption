namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class SimpleCarController : VehicleController<ISimpleCarView>
    {
        public SimpleCarController(ISimpleCarView view) : base(view)
        {
        }
        
    }
}