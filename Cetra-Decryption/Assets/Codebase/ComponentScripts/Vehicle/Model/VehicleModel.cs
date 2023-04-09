using System.Collections.Generic;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public string VehicleName;
        public VehicleHPModel HealthModel;
        public VehicleEngineModel EngineModel;
        public List<VehicleSpringModel> SpringModels = new ();

        public VehicleModel(string name, 
            VehicleHPModel healthModel, 
            VehicleEngineModel engineModel)
        {
            VehicleName = name;
            HealthModel = healthModel;
            EngineModel = engineModel;
        }
    }
}