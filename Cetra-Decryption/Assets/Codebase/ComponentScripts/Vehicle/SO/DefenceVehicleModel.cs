using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "VehicleModels/DefenceVehicle", fileName = "Defence Vehicle Model")]
    public class DefenceVehicleModel : VehicleModelData
    {
        public int Defence;
        
        public override VehicleModel ToModel()
        {
            var model = base.ToModel();
            model.Defence = Defence;
            return model;
        }
    }
}