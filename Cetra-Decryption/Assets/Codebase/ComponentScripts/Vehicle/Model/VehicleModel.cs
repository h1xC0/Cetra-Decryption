using System.Collections.Generic;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public string VehicleName;
        public List<VehicleWheelModel> WheelModels;
    }
}