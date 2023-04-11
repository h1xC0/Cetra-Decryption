using System.Collections.Generic;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public string VehicleName { get; private set; }
        public VehicleHPModel HealthModel { get; private set; }
        public VehicleEngineModel EngineModel { get; private set; }
        public List<VehicleSpringModel> SpringModels { get; private set; }

        public VehicleModel(string name, 
            VehicleHPModel healthModel, 
            VehicleEngineModel engineModel)
        {
            VehicleName = name;
            HealthModel = healthModel;
            EngineModel = engineModel;
            SpringModels = new();
        }
    }
}