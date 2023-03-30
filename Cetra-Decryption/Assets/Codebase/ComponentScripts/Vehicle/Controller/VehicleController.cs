namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class VehicleController : BaseController<IVehicle>
    {
        public VehicleController(IVehicle viewContract) : base(viewContract)
        {
        }
    }
}