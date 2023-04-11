using System.Collections.Generic;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public interface IVehicleModel
    {
        string VehicleName { get; }
        VehicleHPModel HealthModel { get; }
        VehicleEngineModel EngineModel { get; }
        List<VehicleSpringModel> SpringModels { get; }
    }
}