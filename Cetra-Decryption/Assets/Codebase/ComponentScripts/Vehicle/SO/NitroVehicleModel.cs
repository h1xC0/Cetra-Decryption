using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "VehicleModels/NitroVehicle", fileName = "Nitro Vehicle Model")]
    public class NitroVehicleModel : VehicleModelData
    {
        public float Nitro;
        
        public override VehicleModel ToModel()
        {
            var model = base.ToModel();
            model.EngineModel.Nitro = Nitro;
            return model;
        }
    }
}