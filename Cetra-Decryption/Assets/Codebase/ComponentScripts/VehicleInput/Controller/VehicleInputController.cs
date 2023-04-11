using Codebase.ComponentScripts.VehicleInput.Model;
using Codebase.Systems.MVC;

namespace Codebase.ComponentScripts.VehicleInput.Controller
{
    public class VehicleInputController: BaseController<IVehicleInputView>
    {
        public VehicleInputController(IVehicleInputView viewContract, IVehicleInputModel vehicleInputModel) : base(viewContract)
        {
        }

        protected override void Initialize()
        {
            
        }
    }
}