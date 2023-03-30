using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "Models/VehicleModel", fileName = "VehicleModel")]
    public class VehicleModelData : ScriptableObject
    {
        public string VehicleName = "";
        
        public IVehicleModel ToModel()
        {
            return new VehicleModel
            {
                VehicleName = VehicleName
            };
        }
    }
}